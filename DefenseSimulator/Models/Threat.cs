using DefenseSystem.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace DefenseSimulator.Models
{
    public class Threat
    {
        [Key]
        public int ThreatId { get; set; }

        [Required]
        public string Origin { get; set; }
        // New property: Time when the threat was launched
        public DateTime LaunchTime { get; set; }= DateTime.Now;
        // Foreign Key for Weapon
        public int WeaponId { get; set; }
        // Navigation property for Weapon
        public Weapon Weapon { get; set; }
        //// Foreign Key for Response
        //public int? ResponseId { get; set; }
        //// Navigation property for Response
        //public Response? Response { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
