using CarAppointment.Domain.Core.AppointmentAgg.Enums;
using CarAppointment.Domain.Core.CarAgg.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PlateNumber { get; set; }
        public int YearBuilt { get; set; }
        public int ModelId { get; set; }
        public CarModel Model { get; set; }

        public List<AppointmentImage> Images { get; set; }
    }
}
