using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Mod.Commands;
using Mod.Core;
using Mod.Core.Attributes;
using Mod.Database;
using Newtonsoft.Json;

namespace Mod.Events
{
    public class ServerEvents : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public static void OnResourceStart()
        {
            NAPI.Server.SetGlobalDefaultCommandMessages(false);
            NAPI.Server.SetGlobalServerChat(false);

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t == typeof(PlayerCommands)).ToArray();

            foreach (var type in types)
            {
                foreach (var method in type.GetMethods())
                {
                    var command = method.GetCustomAttribute<PlayerCommandAttribute>(); //MY CUSTOM ATTRIBUTE
                    if (command == null) continue;
                    var cmd = new CmdInfo(command, method); //CREATE CMD INFO
                    ChatHandler.Commands.Add(command.Name, cmd); //ADD COMMAND
                    if (command.Aliases == null) continue;
                    foreach (var alias in command.Aliases) ChatHandler.Commands.Add(alias, cmd);
                }
            }

            using DatabaseContext db = new();
            NAPI.Util.ConsoleOutput($"{db.Accounts.Count()}");
        }
    }
}