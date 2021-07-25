using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareIntegration.Models;

namespace SoftwareIntegration.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext (DbContextOptions<ExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<SoftwareIntegration.Models.Exercise> Exercise { get; set; }
    }
}
