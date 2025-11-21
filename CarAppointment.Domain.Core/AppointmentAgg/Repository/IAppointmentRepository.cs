using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Repository
{
    public interface IAppointmentRepository
    {
        public ResultDto AddAppointment(Appointment appointment);
        public ResultDto ApproveAppointment(int appointmentId);
        public ResultDto DenyAppointment(int appointmentId);
        public List<ShowAppointmentsDto> GetAppointmentsForAdmin(DateTime? date = null);
        bool HasAppointmentThisYear(string plateNumber, int year);
        int GetAppointmentCountByDate(DateTime date);



    }
}
