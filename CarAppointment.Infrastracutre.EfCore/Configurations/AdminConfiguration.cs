using CarAppointment.Domain.Core.AdminAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a=>a.Id);

            builder.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a=>a.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                
                new Admin
            {
                Id = 1,
                Username = "admin",
                Password = "admin"
            });
        }
    }
}
