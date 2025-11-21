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
    public class BrandRepository(AppDbContext dbContext):IBrandRepository
    {

        public List<BrandDto> GetAllBrandsWithModels()
        {
            return dbContext.Brands
                .AsNoTracking()
                .Include(b => b.Models)
                .Select(b => new BrandDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Models = b.Models.Select(m => new CarModelDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        BrandId = b.Id
                    }).ToList()
                })
                .ToList();
        }

        public List<SimpleBrandDto> GetAllBrands()
        {
            return dbContext.Brands
                .AsNoTracking()
                .Select(b => new SimpleBrandDto
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
        }

    }
}
