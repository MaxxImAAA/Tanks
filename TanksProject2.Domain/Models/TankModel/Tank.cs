using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Enum;
using TanksProject2.Domain.Models.TankModel.TankComponents;

namespace TanksProject2.Domain.Models.TankModel
{
    public class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public string Made { get; set; }
        public TankType TankType { get; set; }
        
        //public TankCrew TankCrew { get; set; }
        public Firepower Firepower { get; set; }
        public Mobility Mobility { get; set; }
        public Observation Observation { get; set; }
        
    }
}
