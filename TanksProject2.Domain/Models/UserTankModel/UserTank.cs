using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.TankModel;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.Domain.Models.UserTankModel
{
    public class UserTank
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TankId { get; set; }
        public Tank Tank { get; set; }
    }
}
