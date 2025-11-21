using CarAppointment.Domain.Core.CarAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.CarAgg.Contracts.Service
{
    public interface IBrandService
    {
        List<SimpleBrandDto> GetAllBrands();
        List<BrandDto> GetAllBrandsWithModels();
    }
}
