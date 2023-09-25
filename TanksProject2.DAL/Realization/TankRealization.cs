using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Data;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Enum;
using TanksProject2.Domain.Models.TankModel;

namespace TanksProject2.DAL.Realization
{
    public class TankRealization : ITankInterface
    {
        private readonly ApplicationDbContext db;
        public TankRealization(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<bool> Create(Tank modelTank)
        {
            await db.Tanks.AddAsync(modelTank);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(Tank model)
        {
            db.Tanks.Remove(model);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Tank> Get(int id)
        {
            return await db.Tanks.Include(x => x.Firepower).Include(x => x.Mobility).Include(x => x.Observation).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tank>> GetAll()
        {
            return await db.Tanks.Include(x => x.Firepower).Include(x => x.Mobility).Include(x => x.Observation).ToListAsync();
        }

        public async Task<List<Tank>> GetByName(string tankName)
        {
            return await db.Tanks.Where(x => x.Name.Contains(tankName)).Include(x => x.Firepower).Include(x => x.Mobility).Include(x => x.Observation).ToListAsync();
        }

        public async Task<List<Tank>> GetByNation(string nation)
        {
            return await db.Tanks.Where(x=>x.Made == nation).Include(x => x.Firepower).Include(x => x.Mobility).Include(x => x.Observation).ToListAsync();
        }

        public async Task<List<Tank>> GetByType(string type)
        {
            return await db.Tanks.Where(x => x.TankType == (TankType)Convert.ToInt32(type)).Include(x => x.Firepower).Include(x => x.Mobility).Include(x => x.Observation).ToListAsync();
        }

        public async  Task<bool> Update(Tank model)
        {
            db.Tanks.Update(model);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
