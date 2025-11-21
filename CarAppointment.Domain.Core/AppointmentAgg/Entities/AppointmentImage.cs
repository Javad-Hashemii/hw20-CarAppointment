using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Entities
{
    public class AppointmentImage
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
