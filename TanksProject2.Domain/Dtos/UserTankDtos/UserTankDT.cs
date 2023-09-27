using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.DtosTank;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Dtos.UserDtos;
using UserDto = TanksProject2.Domain.Dtos.UserDtos.UserDtos;





namespace TanksProject2.Domain.Dtos.UserTankDtos
{
    public class UserTankDT
    {
        public UserDto UserDto { get; set; }
        public List<TankDtoUser> TankDtoUser { get; set; }

    }
}
