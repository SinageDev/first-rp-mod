using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Mod.Database;
using Mod.DataModels;

namespace Mod.Systems
{
    public class LogIn : Script
    {
        [RemoteEvent("Account:TryRegister")]
        private async Task OnPlayerTryRegister(Player player, string login, string mail, string password, string promo = "")
        {
            await using DatabaseContext db = new();

            var account = new Account
            {
                Login = login,
                Password = password
            };

            await db.Accounts.AddAsync(account);
            await db.SaveChangesAsync();
        }
    }
}