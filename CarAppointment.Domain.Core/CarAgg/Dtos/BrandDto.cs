using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppointment.Domain.Core.CarAgg.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarModelDto> Models { get; set; }
    }
}
