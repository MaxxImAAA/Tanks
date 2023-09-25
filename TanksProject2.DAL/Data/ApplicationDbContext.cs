using Microsoft.EntityFrameworkCore;
using TanksProject2.Domain.Models.TankModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Models.TankModel.TankComponents;
using Microsoft.Identity.Client;
using TanksProject2.Domain.Models.UserModel;

namespace TanksProject2.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tank>Tanks { get; set; }
        public DbSet<Firepower> Firepowers { get; set; }
        public DbSet<Mobility> Mobilities { get; set; }
        public DbSet<Observation> Observations { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<User> Users { get; set; }
       
       
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tank>()
                .HasOne(t => t.Firepower).WithOne(f => f.Tank).HasForeignKey<Firepower>(t => t.TankId);

            modelBuilder.Entity<Tank>()
                .HasOne(t => t.Observation).WithOne(o => o.Tank).HasForeignKey<Observation>(t => t.TankId);

            modelBuilder.Entity<Tank>()
                .HasOne(t => t.Mobility).WithOne(m => m.Tank).HasForeignKey<Mobility>(t => t.TankId);

            modelBuilder.Entity<UserAccount>()
                .HasOne(x => x.User).WithOne(x => x.UserAccount).HasForeignKey<User>(x => x.UserAccountId);

            
               
               
                
                




        }
    }
}
