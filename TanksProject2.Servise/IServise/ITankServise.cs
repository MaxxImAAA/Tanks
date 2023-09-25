using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.Servise;

namespace TanksProject2.Servise.IServise
{
    public interface ITankServise
    {
        Task <ServiseResponse<TankDtos>> AddTank(TankDtos tankDtos);

        Task<ServiseResponse<TankDtos>> GetTank(int id);

        Task<ServiseResponse<List<TankDtos>>> GetAllTank();

        Task<ServiseResponse<bool>> DeleteTank(int id);

        Task<ServiseResponse<TankDtos>> UpdateTank(int id, TankDtos tankDtos);

        Task<ServiseResponse<List<TankDtos>>> GetTankByName(string name);

        Task<ServiseResponse<List<TankDtos>>> GetTanksByType(string type);

        Task<ServiseResponse<List<TankDtos>>> GetTanksByNation(string nation);
    }
}
