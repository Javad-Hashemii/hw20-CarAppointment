using CarAppointment.Domain.Core.AdminAgg.Entities;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.CarAgg.Entities;
using CarAppointment.Infrastracutre.EfCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Common
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
