using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.Servise.IServise
{
    public interface IUserAccountServise
    {
        Task<ServiseResponse<bool>> Register(UserRegistrationDtos userRegistrationDtos);
        Task<ServiseResponse<UserDtos>> Login (string email, string password);
        Task<ServiseResponse<UserDtos>> EditUserAccount(int id, UserRegistrationDtos userRegistrationDtos);
        Task<ServiseResponse<bool>> DeleteUserAccount(int id);
    }
}
