using KlimovPR29.Classes.Common;
using KlimovPR29.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlimovPR29.Classes
{
    public class UserContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UserContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
        }
    }
}
