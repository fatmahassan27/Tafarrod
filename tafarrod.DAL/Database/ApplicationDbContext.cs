using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.DAL.Entities;
using tafarrod.DAL.Enums;

namespace tafarrod.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
            .Property(w => w.CV)
            .HasColumnType("VARBINARY(MAX)"); 

            modelBuilder.Entity<Worker>()
                .Property(w => w.Religion)
                .HasConversion(
                    v => v.ToString(),
                    v => (Religion)Enum.Parse(typeof(Religion), v));

            modelBuilder.Entity<Worker>()
                .Property(w => w.MaritalStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (MaritalStatus)Enum.Parse(typeof(MaritalStatus), v));

            modelBuilder.Entity<Worker>()
                .Property(w => w.PracticalExperience)
                .HasConversion(
                    v => v.ToString(),
                    v => (PracticalExperience)Enum.Parse(typeof(PracticalExperience), v));

            base.OnModelCreating(modelBuilder);
        }
    }
}
