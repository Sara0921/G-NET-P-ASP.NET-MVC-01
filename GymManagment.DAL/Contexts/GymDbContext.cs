using Gym_Mvc_Project.FluentConfigurations;
using Gym_Mvc_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_Mvc_Project.Contexts
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfiguration());
        }
        public  DbSet<Plan> Plans { get; set; }
    }
}
