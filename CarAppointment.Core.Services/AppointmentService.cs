using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.AppointmentAgg.Repository;
using CarAppointment.Domain.Core.AppointmentAgg.Service;
using CarAppointment.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarAppointment.Core.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public ResultDto SubmitAppointment(AddAppointmentDto dto)
        {

            string platePattern = @"^\d{2}\d{3}[\u0600-\u06FF]\d{2}$";
            if (!Regex.IsMatch(dto.PlateNumber, platePattern))
                return new ResultDto { IsSuccess = false, Message = "فرمت پلاک اشتباه است" };

            int currentYear = DateTime.Now.Year;
            if (currentYear - dto.YearBuilt > 5)
                return new ResultDto { IsSuccess = false, Message = "ماشین قدیمی است" };

            if (appointmentRepository.HasAppointmentThisYear(dto.PlateNumber, currentYear))
                return new ResultDto { IsSuccess = false, Message = "این ماشین امسال معاینه شده است." };

            int day = dto.AppointmentDate.Day;
            int maxRequests;
            if (day % 2 == 0)
            {
                maxRequests = 15;
            }
            else
            {
                maxRequests = 10;
            }
            int countForDay = appointmentRepository.GetAppointmentCountByDate(dto.AppointmentDate);

            if (countForDay >= maxRequests)
                return new ResultDto { IsSuccess = false, Message = "ظرفیت امروز تکمیل است." };

            if ((day % 2 == 0 && dto.BrandName != "ایران خودرو") ||
                (day % 2 == 1 && dto.BrandName != "سایپا"))
                return new ResultDto { IsSuccess = false, Message = $"{dto.BrandName} cannot book on this day." };

            var appointment = new Appointment
            {
                Firstname = dto.Firstname,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                NationalCode = dto.NationalCode,
                Address = dto.Address,
                AppointmentDate = dto.AppointmentDate,
                PlateNumber = dto.PlateNumber,
                YearBuilt = dto.YearBuilt,
                ModelId = dto.ModelId,
                Status = AppointmentStatusEnum.Pending
            };

            return appointmentRepository.AddAppointment(appointment);
        }

        public List<ShowAppointmentsDto> GetAppointmentsForAdmin(DateTime? date = null)
        {
            return appointmentRepository.GetAppointmentsForAdmin(date);
        }

        public ResultDto ApproveAppointment(int appointmentId)
        {
            return appointmentRepository.ApproveAppointment(appointmentId);
        }

        public ResultDto DenyAppointment(int appointmentId)
        {
            return appointmentRepository.DenyAppointment(appointmentId);
        }
    }
}
