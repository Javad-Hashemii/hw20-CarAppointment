using CarAppointment.Domain.Core.CarAgg.Contracts.Repository;
using CarAppointment.Domain.Core.CarAgg.Contracts.Service;
using CarAppointment.Domain.Core.CarAgg.Dtos;

namespace CarAppointment.Core.Services
{
    public class CarModelService(ICarModelRepository carModelRepository):ICarModelService
    {
        public List<CarModelDto> GetAllModels()
        {
            return carModelRepository.GetAllModels();
        }

        public List<CarModelDto> GetModelsByBrandId(int brandId)
        {
            return carModelRepository.GetModelsByBrandId(brandId);
        }
    }
}
