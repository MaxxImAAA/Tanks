using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime DataRegistration { get; set; }

        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
