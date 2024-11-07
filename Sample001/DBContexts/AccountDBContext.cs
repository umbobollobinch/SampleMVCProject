using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample001.Models;

namespace Sample001.DBContexts
{
    public class AccountDBContext : DbContext
    {
        public AccountDBContext() : base() { 
        }
        public AccountDBContext(DbContextOptions<AccountDBContext> options) : base(options)
        {
        }
        public virtual DbSet<AccountModel> AccountInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AccountModel>().HasKey(x => new { x.User, x.Pass });
        }

    }
}
