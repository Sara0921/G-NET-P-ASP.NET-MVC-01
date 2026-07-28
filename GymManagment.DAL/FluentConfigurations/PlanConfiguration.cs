using Gym_Mvc_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_Mvc_Project.FluentConfigurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
        {
            builder.Property(P => P.Name)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(P => P.Description)
                .HasMaxLength(200);

            builder.Property(P => P.Price)
                .HasPrecision(10, 2);

            builder.Property(P => P.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(TB =>
            {
                TB.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
            }
                );

        }
    }
}
