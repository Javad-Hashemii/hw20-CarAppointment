using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.AppointmentAgg.Repository;
using CarAppointment.Domain.Core.Common;
using CarAppointment.Infrastracutre.EfCore.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Repositories
{
    public class AppointmentRepository(AppDbContext dbContext):IAppointmentRepository
    {

        public ResultDto AddAppointment(Appointment appointment)
        {
            try
            {
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Appointment added successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = $"Failed to add appointment: {ex.Message}"
                };
            }
        }

        public ResultDto ApproveAppointment(int appointmentId)
        {
            try
            {
                var updated = dbContext.Appointments
                    .Where(a => a.Id == appointmentId)
                    .ExecuteUpdate(a => a.SetProperty(x => x.Status, AppointmentStatusEnum.Approved));

                if (updated == 0)
                    return new ResultDto { IsSuccess = false, Message = "نوبت پیدا نشد" };

                return new ResultDto { IsSuccess = true, Message = "نوبت تایید شد" };
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }
        public ResultDto DenyAppointment(int appointmentId)
        {
            try
            {
                var updated = dbContext.Appointments
                    .Where(a => a.Id == appointmentId)
                    .ExecuteUpdate(a => a.SetProperty(x => x.Status, AppointmentStatusEnum.Denied));

                if (updated == 0)
                    return new ResultDto { IsSuccess = false, Message = "نوبت پیدا نشد" };

                return new ResultDto { IsSuccess = true, Message = "نوبت رد شد" };
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public bool HasAppointmentThisYear(string plateNumber, int year)
        {
            return dbContext.Appointments
                .Any(a => a.PlateNumber == plateNumber && a.AppointmentDate.Year == year);
        }

        public int GetAppointmentCountByDate(DateTime date)
        {
            return dbContext.Appointments
                .AsNoTracking()
                .Count(a => a.AppointmentDate == date);
        }

        public List<ShowAppointmentsDto> GetAppointmentsForAdmin(DateTime? date = null)
        {
            var query = dbContext.Appointments.AsNoTracking();

            // 1. Apply filter first (Performance optimization)
            if (date.HasValue)
            {
                // Note: .Date comparison works well in modern EF Core
                query = query.Where(a => a.AppointmentDate.Date == date.Value.Date);
            }

            return query
                .OrderBy(a => a.AppointmentDate)
                .Select(a => new ShowAppointmentsDto
                {
                    Id = a.Id,
                    Firstname = a.Firstname,
                    LastName = a.LastName,
                    PhoneNumber = a.PhoneNumber,
                    NationalCode = a.NationalCode,
                    AppointmentDate = a.AppointmentDate,
                    PlateNumber = a.PlateNumber,
                    Status = a.Status.ToString(),

                    // EF Core automatically generates the JOINs here
                    ModelName = a.Model.Name,
                    BrandName = a.Model.Brand.Name,
                    ImagePaths = a.Images.Select(i => i.ImagePath).ToList()

                })
                .ToList();
        }

    }
}
