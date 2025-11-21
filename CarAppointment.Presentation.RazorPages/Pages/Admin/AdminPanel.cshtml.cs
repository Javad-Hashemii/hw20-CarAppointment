using CarAppointment.Core.Services;
using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Service;
using Microsoft.AspNetCore.Mvc;
using CarAppointment.Domain.Core.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarAppointment.Presentation.RazorPages.Pages.Admin
{
    public class AdminPanelModel(IAppointmentService appointmentService) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime? FilterDate { get; set; }

        public List<ShowAppointmentsDto> Appointments { get; set; } = new();

        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        public IActionResult OnPostApprove(int appointmentId)
        {
            var result = appointmentService.ApproveAppointment(appointmentId);
            return HandleAction(result);
        }

        public IActionResult OnPostDeny(int appointmentId)
        {
            var result = appointmentService.DenyAppointment(appointmentId);
            return HandleAction(result);
        }

        private IActionResult HandleAction(ResultDto result)
        {
            Message = result.Message;
            IsSuccess = result.IsSuccess; 

            LoadData();
            return Page();
        }

        private void LoadData()
        {
            var result = appointmentService.GetAppointmentsForAdmin(FilterDate);

            if (result != null)
            {
                Appointments = result;
            }
            else
            {
                Appointments = new List<ShowAppointmentsDto>();
            }
        }
    }
}
