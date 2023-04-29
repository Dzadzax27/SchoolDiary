using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryData
{
    public class DiaryDBContex: DbContext
    {
        private string DbPutanja;

        public DiaryDBContex()
        {
            DbPutanja= ConfigurationManager.
                ConnectionStrings["DiaryPutanja"].ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DbPutanja);
        }
        public DbSet<Nastavnici> Nastavnici { get; set; }

    }
}
