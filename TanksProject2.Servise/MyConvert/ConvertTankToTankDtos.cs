using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.TankModel;

namespace TanksProject2.Servise.MyConvert
{
    public class ConvertTankToTankDtos
    {
        private readonly IMapper mapper;
        public ConvertTankToTankDtos(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public TankDtos ConvertToTankDtos(Tank tank)
        {
            var tankDtos = new TankDtos()
            {
                Name = tank.Name,
                Level = tank.Level,
                HP = tank.HP,
                Made = tank.Made,
                Description = tank.Description,
                TankType = tank.TankType.ToString(),




                FirepowerDtos = mapper.Map<FirepowerDtos>(tank.Firepower),
                MobilityDtos = mapper.Map<MobilityDtos>(tank.Mobility),
                ObservationDtos = mapper.Map<ObservationDtos>(tank.Observation)
            };
            return tankDtos;

        }
    }
}
