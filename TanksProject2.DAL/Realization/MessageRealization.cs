using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Data;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Models.MessageModels;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.DAL.Realization
{
    public class MessageRealization : IMessageInterface
    {
        private readonly ApplicationDbContext db;
        public MessageRealization(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Create(Message model)
        {
            await db.Messages.AddAsync(model);
           await db.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAll(int ReciverId)
        {
            return await db.Messages.Where(x => x.ReciverId == ReciverId).Include(x => x.Sender).ToListAsync();
        }

        public async Task<List<Message>> GetAllSenderMessage(User sender)
        {
            return await db.Messages.Where(x => x.Sender == sender).ToListAsync();   
        }
    }
}
