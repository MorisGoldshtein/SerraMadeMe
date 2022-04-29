using System.Web;

namespace APIProject.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }
        public List<Character> CharactersList { get; set; } = new();
        public List<Weapon> WeaponsList { get; set; } = new();
    }
}
