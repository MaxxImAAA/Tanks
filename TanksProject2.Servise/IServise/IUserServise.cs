using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.UserTankDtos;
using TanksProject2.Domain.Models.Servise;

namespace TanksProject2.Servise.IServise
{
    public interface IUserServise
    {
        Task<ServiseResponse<bool>> AddTank(int userId, int tankId);

        Task<ServiseResponse<UserTankDT>> GetTanks(int userId);
    }
}
