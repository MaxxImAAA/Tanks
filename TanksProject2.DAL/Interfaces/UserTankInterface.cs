using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.TankModel;
using TanksProject2.Domain.Models.UserModel;
using TanksProject2.Domain.Models.UserTankModel;

namespace TanksProject2.DAL.Interfaces
{
    public interface UserTankInterface
    {
        Task<bool> Create(UserTank model);

        Task<User> GetUserAndTanks(int userId);

        Task<bool> DeleteTank(User userModel, Tank tankModel);
    }
}
