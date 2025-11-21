using CarAppointment.Domain.Core.CarAgg.Contracts.Repository;
using CarAppointment.Domain.Core.CarAgg.Dtos;
using CarAppointment.Infrastracutre.EfCore.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Infrastracutre.EfCore.Repositories
{
    public class CarModelRepository(AppDbContext dbContect):ICarModelRepository
    {
        public List<CarModelDto> GetModelsByBrandId(int brandId)
        {
            return dbContect.Models
                .AsNoTracking()
                .Where(m => m.BrandId == brandId)
                .Select(m => new CarModelDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    BrandId = m.BrandId
                })
                .ToList();
        }

        public List<CarModelDto> GetAllModels()
        {
            return dbContect.Models
                .AsNoTracking()
                .Select(m => new CarModelDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    BrandId = m.BrandId
                })
                .ToList();
        }
    }
}
