using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.CarAgg.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Dtos
{
    public class AddAppointmentDto
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PlateNumber { get; set; }
        public int YearBuilt { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
