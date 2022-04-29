using System;
namespace APIProject.Models
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string? WeaponName { get; set; }
        public string? Class { get; set; }
        public int Impact { get; set; }
        public int Range { get; set; }
        public int Stability { get; set; }
        public int Handling { get; set; }
        public int ReloadSpeed { get; set; }
    }
}
