using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Dtos.TankDtos
{
    public class FirepowerDtos
    {
        public string GunName { get; set; } //Название орудия 
        public int Ammunition { get; set; } //Количество снарядов в боекомплекте
        public int Damage { get; set; } // Разовый урон
        public decimal RateOfFire { get; set; } // Перезарядка орудия (Секунды)
    }
}
