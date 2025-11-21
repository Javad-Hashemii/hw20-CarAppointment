using CarAppointment.Domain.Core.AdminAgg.Entities;
using CarAppointment.Domain.Core.AdminAgg.Repository;
using CarAppointment.Infrastracutre.EfCore.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Repositories
{
    public class AdminRepository(AppDbContext dbcontext):IAdminRepository
    {
        public Admin? GetByUsernamePassword(string username, string password)
        {
            return dbcontext.Admins
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();
        }
    }
    
}
