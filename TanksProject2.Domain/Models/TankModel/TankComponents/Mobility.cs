using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Models.TankModel.TankComponents
{
    public class Mobility
    {
        public int Id { get;set; }

        public int EnginePower { get; set; } // Мощность двигателя (Лошадиные силы)
        public int SpeedForward { get; set; } // Скорость вперед (КМ/Ч)
        public int SpeedBack { get; set; } // Скорость назад  (КМ/Ч)

        public int TankId { get; set; }
        public Tank Tank {  get; set; }
    }
}
