using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.CarAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Dtos
{
    public class ShowAppointmentsDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PlateNumber { get; set; }
        public int YearBuilt { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
    }
}
