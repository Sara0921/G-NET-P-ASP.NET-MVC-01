using GymManagment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.FluentConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(X => X.CategoryName)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(X => X.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            //Sending Cardio , Strength , Yoga ,CrossFit
            //HasData => MusT Send 'ID' , Disable Identity ID

            builder.HasData(
                new Category {Id = 1 , CategoryName = "Cardio" },
                new Category {Id = 2 , CategoryName = "Stength"},
                new Category { Id = 3, CategoryName = "Yoga" },
                new Category { Id = 4, CategoryName = "CrossFit" }

                );

        }
    }
}
