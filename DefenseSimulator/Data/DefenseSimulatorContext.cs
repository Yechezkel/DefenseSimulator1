using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DefenseSystem.Data.Models;
using DefenseSimulator.Models;

namespace DefenseSimulator.Data
{
    public class DefenseSimulatorContext : DbContext
    {
        public DefenseSimulatorContext (DbContextOptions<DefenseSimulatorContext> options)
            : base(options)
        {
        }

        public DbSet<DefenseSystem.Data.Models.Weapon> Weapon { get; set; } = default!;
        public DbSet<DefenseSimulator.Models.Threat> Threat { get; set; } = default!;
        public DbSet<DefenseSimulator.Models.Response> Response { get; set; } = default!;
        public DbSet<DefenseSimulator.Models.Arsenal> Arsenal { get; set; } = default!;
    }
}
