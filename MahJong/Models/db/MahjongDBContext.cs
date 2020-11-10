using MahJong.Models.db.table;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ผูกคลาส Employee กับตาราง Memployeespinder ให้เชื่อมถึงกันได้
            modelBuilder.Entity<Stores>().ToTable("Store");
        }
    }
}
