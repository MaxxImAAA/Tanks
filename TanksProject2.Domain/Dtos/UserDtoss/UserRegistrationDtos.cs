using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Dtos.UserDtos
{
    public class UserRegistrationDtos
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
    }
}
