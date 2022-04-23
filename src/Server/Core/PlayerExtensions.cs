using GTANetworkAPI;

namespace Mod.Core
{
    public static class PlayerExtensions
    {
        public static void SendMessage(this Player player, string text) => ChatHandler.SendPlayerMessage(player, text);
    }
}