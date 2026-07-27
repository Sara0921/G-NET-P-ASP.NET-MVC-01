using Gym_Mvc_Project.FluentConfigurations;
using Gym_Mvc_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_Mvc_Project.Contexts
{
    public class GymDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = GymDb ;Trusted_Connection = true ; TrustServerCertificate = true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfiguration());
        }
        public  DbSet<Plan> Plans { get; set; }
    }
}
