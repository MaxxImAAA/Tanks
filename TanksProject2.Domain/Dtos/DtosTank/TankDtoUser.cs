using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Dtos.DtosTank
{
    public class TankDtoUser
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public string Made { get; set; }
        public string TankType { get; set; }
    }
}
