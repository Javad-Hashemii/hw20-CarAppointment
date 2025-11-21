using CarAppointment.Core.Services;
using CarAppointment.Domain.Core.AppointmentAgg.Dtos;
using CarAppointment.Domain.Core.AppointmentAgg.Entities;
using CarAppointment.Domain.Core.AppointmentAgg.Service;
using CarAppointment.Domain.Core.CarAgg.Contracts.Service;
using CarAppointment.Domain.Core.CarAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace CarAppointment.Presentation.RazorPages.Pages.Appointment
{
    public class CreateModel(IAppointmentService appointmentService, IBrandService brandService, ICarModelService carModelService) : PageModel
    {

        [BindProperty]
        public AddAppointmentDto AppointmentDto { get; set; }

        public List<SimpleBrandDto> Brands { get; set; }
        public List<CarModelDto> Models { get; set; }

        [BindProperty]
        public string PlatePart1 { get; set; }

        [BindProperty]
        public string PlatePart2 { get; set; }

        [BindProperty]
        public string PlatePart3 { get; set; }

        [BindProperty]
        public string PlatePart4 { get; set; }

        public string Message { get; set; }
        public bool IsSucces { get; set; }

        public void OnGet()
        {
            LoadDropdowns();
        }

        public IActionResult OnPost()
        {
            AppointmentDto.PlateNumber = $"{PlatePart4}{PlatePart3}{PlatePart2}{PlatePart1}";
            var result = appointmentService.SubmitAppointment(AppointmentDto);
            if (!result.IsSuccess)
            {
                
                Message = result.Message;
                IsSucces = false;
                LoadDropdowns();
                return Page();
            }
            IsSucces= true;
            Message = "وقت معاینه با موفقیت ثبت شد.";
            ModelState.Clear();
            AppointmentDto = new AddAppointmentDto();
            LoadDropdowns();
            return Page();
        }

        private void LoadDropdowns()
        {
            Brands = brandService.GetAllBrands();
            Models = carModelService.GetAllModels();
        }

    }
}
