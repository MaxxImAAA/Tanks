using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.MessageModels;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.DAL.Interfaces
{
    public interface IMessageInterface
    {
        Task Create(Message model);
        Task<List<Message>> GetAll(int ReciverId);

        Task<List<Message>> GetAllSenderMessage(User sender);
    }
}
