using CarAppointment.Core.Services;
using CarAppointment.Domain.Core.AdminAgg.Repository;
using CarAppointment.Domain.Core.AdminAgg.Service;
using CarAppointment.Domain.Core.AppointmentAgg.Repository;
using CarAppointment.Domain.Core.AppointmentAgg.Service;
using CarAppointment.Domain.Core.CarAgg.Contracts.Repository;
using CarAppointment.Domain.Core.CarAgg.Contracts.Service;
using CarAppointment.Infrastracutre.EfCore.Common;
using CarAppointment.Infrastracutre.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Hw20;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<ICarModelService, CarModelService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
