using DefenseSystem.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace DefenseSimulator.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        [Required]
        public int ThreatId { get; set; }
        public Threat Threat { get; set; }
        [Required]
        public DateTime LaunchTime { get; set; }= DateTime.Now;
        public DateTime? InterceptTime { get; set; }
        public CounterType ResponseType { get; set; }
        public ResponseStatus Status { get; set; } = ResponseStatus.Active;
    }
    public enum ResponseStatus
    {
        Active,
        Success,
        Fail
    }
}
