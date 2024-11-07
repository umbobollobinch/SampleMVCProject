using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample001.Models;

namespace Sample001.DBContexts
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base() { 
        }
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {
        }

        public DbSet<PositiveCaseModel> Covid19Results { get; set; } //こういうのをメンバ変数と呼ぶ
        public DbSet<Models.Prefs.FukuiModel> FukuiResults { get; set; }
        public DbSet<Models.Prefs.GunmaModel> GunmaResults { get; set; }
        public DbSet<Models.Prefs.KanagawaModel> KanagawaResults { get; set; }
    }
}
