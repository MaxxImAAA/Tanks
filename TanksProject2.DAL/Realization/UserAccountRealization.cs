using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Data;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.DAL.Realization
{
    public class UserAccountRealization : IUserAccountInterface
    {
        private readonly ApplicationDbContext db;
        public UserAccountRealization(ApplicationDbContext db)
        {
            this.db = db;
            
        }
        public async Task<bool> Create(UserAccount model)
        {
            await db.UserAccounts.AddAsync(model);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<UserAccount> Get(int id)
        {
            var user =  await db.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);
            await db.Entry(user).Reference(x => x.User).LoadAsync();
            return user;
        }

        public async Task<List<UserAccount>> GetAll()
        {
            return await db.UserAccounts.Include(x => x.User).ToListAsync();
            
            
        }

        public async Task<UserAccount> Update(UserAccount model)
        {
            db.UserAccounts.Update(model);
            await db.SaveChangesAsync();
            return model;
        }
    }
}
