using CarAppointment.Domain.Core.AdminAgg.Dtos;
using CarAppointment.Domain.Core.AdminAgg.Entities;
using CarAppointment.Domain.Core.AdminAgg.Repository;
using CarAppointment.Domain.Core.AdminAgg.Service;

namespace CarAppointment.Core.Services
{
    public class AdminService(IAdminRepository adminRepository) : IAdminService
    {
        public AdminDto? Login(string username, string password)
        {

            var admin = adminRepository.GetByUsernamePassword(username, password);

            if (admin != null)
            {
                return new AdminDto
                {
                    Id = admin.Id,
                    Username = admin.Username
                };
            }
            return null;
        }
    }
}
