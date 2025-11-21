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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Model)
                .WithMany(m => m.Appointments)
                .HasForeignKey(a => a.ModelId);

            builder.HasMany(a => a.Images)
                   .WithOne(i => i.Appointment)
                   .HasForeignKey(i => i.AppointmentId);

            builder.Property(a => a.Firstname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.NationalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(a => a.PlateNumber)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(a => a.YearBuilt)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasData(
                new Appointment
                {
                    Id = 1,
                    Firstname = "علی",
                    LastName = "محمدی",
                    PhoneNumber = "09121234567",
                    NationalCode = "1234567890",
                    Address = "تهران، خیابان انقلاب، پلاک 10",
                    AppointmentDate = new DateTime(2025, 12, 2, 14, 30, 0),
                    PlateNumber = "12ب34567",
                    YearBuilt = 2020,
                    ModelId = 1,
                    Status = Domain.Core.AppointmentAgg.Enums.AppointmentStatusEnum.Pending
                },
                new Appointment 
                {
                    Id = 2,
                    Firstname = "شاپور",
                    LastName = "حسینی",
                    PhoneNumber = "09331234568",
                    NationalCode = "1854567890",
                    Address = "تهران، خیابان انقلاب، پلاک 12",
                    AppointmentDate = new DateTime(2025, 12, 1, 10, 0, 0),
                    PlateNumber = "12ب34567",
                    YearBuilt = 2020,
                    ModelId = 1,
                    Status = Domain.Core.AppointmentAgg.Enums.AppointmentStatusEnum.Pending
                }
                );

        }
    }
}
