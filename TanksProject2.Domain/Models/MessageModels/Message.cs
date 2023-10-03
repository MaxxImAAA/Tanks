using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.Domain.Models.MessageModels
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int ReciverId { get; set; }
        public User Reciver { get; set; }

    }
}
