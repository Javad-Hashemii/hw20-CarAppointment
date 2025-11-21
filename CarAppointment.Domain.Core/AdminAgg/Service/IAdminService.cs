using CarAppointment.Domain.Core.AdminAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AdminAgg.Service
{
    public interface IAdminService
    {
        AdminDto? Login(string username, string password);
    }
}
