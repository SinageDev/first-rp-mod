using System.ComponentModel.DataAnnotations;
using Mod.Entity;

namespace Mod.DataModels
{
    public class Account : DataInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}