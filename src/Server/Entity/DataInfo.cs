using System.ComponentModel.DataAnnotations;

namespace Mod.Entity
{
    public abstract class DataInfo
    {
        [Key]
        public int Id { get; set; }
    }
}