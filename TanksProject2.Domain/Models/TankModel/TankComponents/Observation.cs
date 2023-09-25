using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Models.TankModel.TankComponents
{
    public class Observation
    {
        public int Id { get; set; }

        public int Review { get; set; } // Обзор (Метры)
        public int CommunicationRange { get; set; } // Дальность сявязи (Метры)

        public int TankId { get; set; }
        public Tank Tank { get; set; }
    }
}
