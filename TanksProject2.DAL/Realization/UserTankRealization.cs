using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Data;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Models.TankModel;
using TanksProject2.Domain.Models.UserModel;
using TanksProject2.Domain.Models.UserTankModel;

namespace TanksProject2.DAL.Realization
{
    public class UserTankRealization : UserTankInterface
    {
        private readonly ApplicationDbContext db;
        public UserTankRealization(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        public async Task<bool> Create(UserTank model)
        {
           await db.UserTanks.AddAsync(model);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserAndTanks(int userId)
        {
            return await db.Users.Include(x=>x.UserTanks).ThenInclude(x=>x.Tank).FirstOrDefaultAsync(x=>x.Id == userId);
        }
    }
}
