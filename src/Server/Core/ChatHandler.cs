using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using GTANetworkAPI;
using Mod.Core.Attributes;
using Newtonsoft.Json;

namespace Mod.Core
{
    public class CmdInfo
    {
        public byte? AdminLevel;
        public MethodInfo Method;

        public CmdInfo(PlayerCommandAttribute from, MethodInfo method)
        {
            AdminLevel = from.Admin;
            Method = method;
        }
    }

    public class ChatHandler : Script
    {
        public static Dictionary<string, CmdInfo> Commands = new();

        [RemoteEvent("Chat:TryCommand")]
        public void TryInvokeCommand(Player player, string command, string parseArgs)
        {
            if (Commands.TryGetValue(command, out var cmdInfo))
            {
                var args = JsonConvert.DeserializeObject<List<object>>(parseArgs);

                if (!Server.Characters.Is(player)) return;
                if (cmdInfo.AdminLevel != null && Server.Admins.Get(player).Level < cmdInfo.AdminLevel) return;

                var methodParams = cmdInfo.Method.GetParameters().Where(x => x.ParameterType != typeof(Player))
                    .ToArray();

                if (args.Count < methodParams.Count(x => !x.IsOptional)) //CHECK COUNT ARGUMENTS
                {
                    player.SendMessage(GenerateCommandError(command, methodParams));
                    return;
                }

                for (var i = 0; i < methodParams.Length; i++)
                    if (i >= args.Count && methodParams[i].IsOptional) args.Add(methodParams[i].DefaultValue);

                args.Insert(0, player);
                cmdInfo.Method.Invoke(null, args.ToArray());
            }
            else player.SendMessage($"Команды /{command} не найдено!");
        }

        public static string GenerateCommandError(string command, ParameterInfo[] parameters)
        {
            var error = new StringBuilder($"Используйте: /{command}. Аргументы: ");
            foreach (var param in parameters)
            {
                error.Append((param.IsOptional ? $"{{{param.Name}}}" : $"[{param.Name}]") + " ");
            }
            return error.ToString();
        }

        [RemoteEvent("Chat:Message")]
        public static void InvokeMessage(Player player, string text)
        {

        }

        public static void SendPlayerMessage(Player player, string text)
        {
            player.TriggerEvent("chat:sendMessage", text);
        }
    }
}