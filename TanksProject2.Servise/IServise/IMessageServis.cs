using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.MessageModels;
using TanksProject2.Domain.Models.Servise;

namespace TanksProject2.Servise.IServise
{
    public interface IMessageServis
    {
        Task<ServiseResponse<MessageServis>> SendMessage(string message, int SenderId, int ReciverId);

        Task<ServiseResponse<List<MessageServis>>> ListenMessage(int ReciverId);
    }
}
