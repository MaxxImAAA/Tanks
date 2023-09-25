using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.TankModel;

namespace TanksProject2.DAL.Interfaces
{
    public interface ITankInterface
    {
        Task<bool> Create(Tank modelTank);

        Task<Tank> Get(int id);

        Task<List<Tank>> GetAll();

        Task<bool> Delete(Tank model);

        Task<bool> Update(Tank model);

        Task<List<Tank>> GetByName(string tankName);

        Task<List<Tank>> GetByType(string type);

        Task<List<Tank>> GetByNation(string nation);

        
    }
}
