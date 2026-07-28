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
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(X => X.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(X => X.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasIndex(X => X.Email).IsUnique();
            builder.HasIndex(X => X.Phone).IsUnique();


            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("EmailCheck", "Email Like '_%@_%._%'"); //Email Contain '@' and ','
                tb.HasCheckConstraint("PhoneCheck", "Phone Like '010' or Phone Like '012' or Phone Like '015' or Phone Like '011'"); //Phone Start 010 or 012 or 015 or 011
            });

            //Address Owned Entity Type
            builder.OwnsOne(X => X.Address, address =>
            {
                address.Property(X => X.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(50);
                address.Property(X => X.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(50);

            });







        }
    }
}
