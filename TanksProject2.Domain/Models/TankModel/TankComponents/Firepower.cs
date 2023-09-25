using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Models.TankModel.TankComponents
{
    public class Firepower
    {
        public int Id { get; set; }

        public string GunName { get; set; } //Название орудия 
        public int Ammunition { get; set; } //Количество снарядов в боекомплекте
        public int Damage { get; set; } // Разовый урон
        public decimal RateOfFire { get; set; } // Перезарядка орудия (Секунды)

        public int TankId { get ; set; }
        public Tank Tank { get; set; }
    }
}
