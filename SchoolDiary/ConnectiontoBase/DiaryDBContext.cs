
using SchoolDiary.ConnectiontoBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DiaryData2
{
    public class DiaryDBContext : DbContext
    {
        public DiaryDBContext() : base("DiaryPutanja")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nastavnici>().ToTable("Nastavnici");
            modelBuilder.Entity<Studenti>().ToTable("Studenti");
            modelBuilder.Entity<Subjects>().ToTable("Subjects");
            modelBuilder.Entity<SubjectsStudent>().ToTable("SubjectsStudents");
        }
        public DbSet<Nastavnici> Nastavnici { get;set; }
        public DbSet<Studenti> Studenti { get;set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<SubjectsStudent> SubjectsStudents { get; set; }
    }
}
