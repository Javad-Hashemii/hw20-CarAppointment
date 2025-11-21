using CarAppointment.Domain.Core.CarAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Configurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new CarModel
                {
                    Id = 1,
                    Name = "شاهین",
                    BrandId = 1

                },
                new CarModel
                {
                    Id=2,
                    Name="207",
                    BrandId=2
                }
                );
        }
    }
}
