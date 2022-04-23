using GTANetworkAPI;
using Mod.DataModels;
using Mod.Entity;

namespace Mod
{
    public static class Server
    {
        public static EntitiesManager<Player, Account> Accounts = new();
        public static EntitiesManager<Player, Character> Characters = new();
        public static EntitiesManager<Player, Admin> Admins = new();
        public static EntitiesManager<int, Business> Business = new();
    }
}