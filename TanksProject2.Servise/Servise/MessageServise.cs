using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Models.MessageModels;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.UserModel;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Servise.Servise
{
    public class MessageServise : IMessageServis
    {
        private readonly IMessageInterface _message;
        public MessageServise(IMessageInterface _message)
        {
            this._message = _message;
        }

        public async Task<ServiseResponse<List<MessageServis>>> ListenMessage(int ReciverId)
        {
            var serviseResponse = new ServiseResponse<List<MessageServis>>();
            try
            {
                List<MessageServis> messageServisList = new List<MessageServis>();

                List<Message> ReciverMessages = await _message.GetAll(ReciverId); // Получение всех сообщений у которых получатель ReciverId
                List<User> Senders = ReciverMessages.Select(x => x.Sender).Distinct().ToList(); // Получение всех уникальных всех оптравителей Sender получателю Reciver
                foreach(var item1 in Senders)
                {
                    var messageServis = new MessageServis();
                    messageServis.Messages = new List<string>();

                    messageServis.SenderName = item1.NickName;
                    List<Message> SenderMessages = await _message.GetAllSenderMessage(item1);

                    foreach(var item2 in  SenderMessages)
                    {
                        messageServis.Messages.Add(item2.Content);
                    }
                    messageServisList.Add(messageServis);

                }
                serviseResponse.Data = messageServisList;
                serviseResponse.Description = "Сообщения получены";
                serviseResponse.StatusCode = Domain.Enum.StatusCode.OK;

            }
            catch(Exception ex)
            {
                serviseResponse.Description = $"[ListenMessage] : {ex.Message}";
                serviseResponse.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return serviseResponse;
        }

        public async Task<ServiseResponse<MessageServis>> SendMessage(string message, int SenderId, int ReciverId)
        {
            var serviseResponse = new ServiseResponse<MessageServis>();
            try
            {
                var msg = new Message()
                {
                    Content = message,

                    SenderId = SenderId,
                    ReciverId = ReciverId
                };
               await _message.Create(msg);

                serviseResponse.Description = "Сообщение отправленно";
                serviseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                

            }
            catch(Exception ex)
            {
                serviseResponse.Description = $"[SendMessage] : {ex.Message}";
                serviseResponse.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return serviseResponse;
            
        }
    }
}
