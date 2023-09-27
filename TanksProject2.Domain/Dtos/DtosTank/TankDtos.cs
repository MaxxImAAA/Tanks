using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.TankModel;

namespace TanksProject2.Domain.Dtos.TankDtos
{
    public class TankDtos
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public string Made { get; set; }
        public string TankType { get; set; }

        
        public FirepowerDtos FirepowerDtos { get; set; }
        public MobilityDtos MobilityDtos { get; set; }
        public ObservationDtos ObservationDtos { get; set; }
    }
}
