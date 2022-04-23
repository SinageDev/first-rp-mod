using GTANetworkAPI;
using Mod.Core.Attributes;

namespace Mod.Commands
{
    public partial class PlayerCommands : Script
    {
        [PlayerCommand("veh", Admin = 1)]
        public static void Cmd_Vehicle(Player player, string hash, int color1 = 0, int color2 = 0) //CMD VEH
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(hash), player.Position, player.Heading,
                color1, color2);

            player.SetIntoVehicle(vehicle, -1);
            player.SendChatMessage("Вы успешно заспавнили автомобиль");
        }

        [PlayerCommand("weapon", Admin = 1)]
        public static void Cmd_GiveWeapon(Player player, WeaponHash hash, int ammo = 1000)
        {
            player.GiveWeapon(hash, ammo);
        }
    }
}