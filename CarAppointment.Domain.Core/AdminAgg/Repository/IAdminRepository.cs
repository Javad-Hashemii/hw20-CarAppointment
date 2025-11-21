using CarAppointment.Domain.Core.AdminAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.AdminAgg.Repository
{
    public interface IAdminRepository
    {
        public Admin? GetByUsernamePassword(string username, string password);

    }
}
