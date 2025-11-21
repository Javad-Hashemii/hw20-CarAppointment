using CarAppointment.Domain.Core.CarAgg.Contracts.Repository;
using CarAppointment.Domain.Core.CarAgg.Contracts.Service;
using CarAppointment.Domain.Core.CarAgg.Dtos;

namespace CarAppointment.Core.Services
{
    public class BrandService(IBrandRepository brandRepository):IBrandService
    {
        public List<SimpleBrandDto> GetAllBrands()
        {
            return brandRepository.GetAllBrands();
        }

        public List<BrandDto> GetAllBrandsWithModels()
        {
            return brandRepository.GetAllBrandsWithModels();
        }
    }
}
