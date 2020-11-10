using MahJong.Models.db.table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorMonitoring.Models
{
    public class MahjongDBContext : DbContext
    {
        public MahjongDBContext()
        {

        }
        public MahjongDBContext(DbContextOptions<MahjongDBContext> options)
            : base(options)
        {
        }

        public DbSet<Stores> Stores { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ผูกคลาส Employee กับตาราง Memployeespinder ให้เชื่อมถึงกันได้
            modelBuilder.Entity<Stores>()
                .ToTable("Store")
                .HasKey(s => s.s_id);

            modelBuilder.Entity<Book>()
                .ToTable("Book")
                .HasKey(b => b.b_id);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasKey(c => c.c_id);
        }     
    }
}
