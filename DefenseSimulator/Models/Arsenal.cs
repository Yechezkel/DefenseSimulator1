using DefenseSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DefenseSimulator.Models
{
    public class Arsenal
    {
        [Key]
        public CounterType Counter { get; set; }
        public int Amount { get; set; }
    }
}
