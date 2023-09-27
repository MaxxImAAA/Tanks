using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Dtos.TankDtos
{
    public class ObservationDtos
    {
        public int Review { get; set; } // Обзор (Метры)
        public int CommunicationRange { get; set; } // Дальность сявязи (Метры)
    }
}
