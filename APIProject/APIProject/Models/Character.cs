using System;

namespace APIProject.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Weapon1Id { get; set; }
        public int? Weapon2Id { get; set; }
        public int? Weapon3Id { get; set; }
    }
}
