using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.DAL.Interfaces
{
    public interface IUserAccountInterface
    {
        Task<bool> Create(UserAccount model);

        Task<List<UserAccount>> GetAll();

        Task<UserAccount> Get(int id);

        Task<UserAccount> Update (UserAccount model);
    }
}
