using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.AppointmentAgg.Repository;
using CarAppointment.Domain.Core.AppointmentAgg.Service;
using CarAppointment.Domain.Core.Common;
using Microsoft.AspNetCore.Http;
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

            int persianDayNumber = (((int)dto.AppointmentDate.DayOfWeek + 2) % 7) + 1;
            bool isEvenWeekday = persianDayNumber % 2 == 0;

            int maxRequests;
            if (isEvenWeekday)
            {
                maxRequests = 15;
            }
            else
            {
                maxRequests = 10;
            }

            int countForDay = appointmentRepository.GetAppointmentCountByDate(dto.AppointmentDate);

            if (countForDay >= maxRequests)
            {
                return new ResultDto { IsSuccess = false, Message = "ظرفیت امروز تکمیل است." };
            }

            if (isEvenWeekday && dto.BrandName != "ایران خودرو")
            {
                return new ResultDto { IsSuccess = false, Message = "ایران خودرو فقط در روزهای زوج رزرو می‌شود." };
            }

            if (!isEvenWeekday && dto.BrandName != "سایپا")
            {
                return new ResultDto { IsSuccess = false, Message = "سایپا فقط در روزهای فرد رزرو می‌شود." };
            }

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
                Status = AppointmentStatusEnum.Pending,
                CreatedAt = DateTime.Now,
                Images = new List<AppointmentImage>()
            };

            if (dto.ImageFiles != null && dto.ImageFiles.Count > 0)
            {
                foreach (var file in dto.ImageFiles)
                {
                    if (file.Length > 0)
                    {
                        string path = Upload(file, "appointments");

                        appointment.Images.Add(new AppointmentImage
                        {
                            ImagePath = path
                        });
                    }
                }
            }

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

        public string Upload(IFormFile file, string folder)
        {

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsFolder, uniqueFileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("Files", folder, uniqueFileName).Replace("\\", "/");
        }
    }
}
