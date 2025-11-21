using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AppointmentAgg.Service
{
    public interface IAppointmentService
    {
        public ResultDto DenyAppointment(int appointmentId);
        public List<ShowAppointmentsDto> GetAppointmentsForAdmin(DateTime? date = null);
        public ResultDto ApproveAppointment(int appointmentId);
        public ResultDto SubmitAppointment(AddAppointmentDto dto);


    }
}
