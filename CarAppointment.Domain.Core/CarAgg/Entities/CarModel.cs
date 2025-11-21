using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.CarAgg.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
