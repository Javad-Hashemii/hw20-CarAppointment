using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Configurations
{
    public class AppointmentImageConfiguration : IEntityTypeConfiguration<AppointmentImage>
    {
        public void Configure(EntityTypeBuilder<AppointmentImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.Appointment)
                .WithMany(a => a.Images)
                .HasForeignKey(x => x.AppointmentId);

        }
    }
}
