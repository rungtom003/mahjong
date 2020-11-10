using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MahJong.Models.databases
{
    public partial class mahjongContext : DbContext
    {
        public mahjongContext()
        {
        }

        public mahjongContext(DbContextOptions<mahjongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminStore> AdminStore { get; set; }
        public virtual DbSet<AdminSystem> AdminSystem { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookDetail> BookDetail { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<RightAdminStore> RightAdminStore { get; set; }
        public virtual DbSet<RightAdminSystem> RightAdminSystem { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=116.204.181.117;Initial Catalog=mahjong;User ID=sa;Password=Rungtom003;",
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminStore>(entity =>
            {
                entity.HasKey(e => e.AsId);

                entity.Property(e => e.AsId).HasColumnName("as_id");

                entity.Property(e => e.AsLname)
                    .HasColumnName("as_lname")
                    .HasMaxLength(100);

                entity.Property(e => e.AsName)
                    .HasColumnName("as_name")
                    .HasMaxLength(100);

                entity.Property(e => e.AsPassword)
                    .HasColumnName("as_password")
                    .HasMaxLength(50);

                entity.Property(e => e.AsTel)
                    .HasColumnName("as_tel")
                    .HasMaxLength(50);

                entity.Property(e => e.AsUsername)
                    .HasColumnName("as_username")
                    .HasMaxLength(50);

                entity.Property(e => e.RasId)
                    .HasColumnName("ras_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SId)
                    .HasColumnName("s_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ras)
                    .WithMany(p => p.AdminStore)
                    .HasForeignKey(d => d.RasId)
                    .HasConstraintName("FK_AdminStore_RightAdminStore");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.AdminStore)
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("FK_AdminStore_Store");
            });

            modelBuilder.Entity<AdminSystem>(entity =>
            {
                entity.HasKey(e => e.AId);

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.ALname)
                    .HasColumnName("a_lname")
                    .HasMaxLength(100);

                entity.Property(e => e.AName)
                    .HasColumnName("a_name")
                    .HasMaxLength(100);

                entity.Property(e => e.APassword)
                    .HasColumnName("a_password")
                    .HasMaxLength(50);

                entity.Property(e => e.ATel)
                    .HasColumnName("a_tel")
                    .HasMaxLength(50);

                entity.Property(e => e.AUsername)
                    .HasColumnName("a_username")
                    .HasMaxLength(50);

                entity.Property(e => e.RastId)
                    .HasColumnName("rast_id")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Rast)
                    .WithMany(p => p.AdminSystem)
                    .HasForeignKey(d => d.RastId)
                    .HasConstraintName("FK_AdminSystem_RightAdminSystem");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BId);

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.BDate)
                    .HasColumnName("b_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BPriceTotal).HasColumnName("b_priceTotal");

                entity.Property(e => e.BQuantity).HasColumnName("b_quantity");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK_Book_Customer");
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.BdId);

                entity.Property(e => e.BdId).HasColumnName("bd_id");

                entity.Property(e => e.BId).HasColumnName("b_id");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.HasOne(d => d.B)
                    .WithMany(p => p.BookDetail)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("FK_BookDetail_Book");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.BookDetail)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK_BookDetail_Table");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CBirthdate)
                    .HasColumnName("c_birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.CFname)
                    .HasColumnName("c_fname")
                    .HasMaxLength(100);

                entity.Property(e => e.CLname)
                    .HasColumnName("c_lname")
                    .HasMaxLength(100);

                entity.Property(e => e.CTel)
                    .HasColumnName("c_tel")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RightAdminStore>(entity =>
            {
                entity.HasKey(e => e.RasId);

                entity.Property(e => e.RasId)
                    .HasColumnName("ras_id")
                    .HasMaxLength(50);

                entity.Property(e => e.RasDetail)
                    .HasColumnName("ras_detail")
                    .HasMaxLength(100);

                entity.Property(e => e.RasName)
                    .HasColumnName("ras_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RightAdminSystem>(entity =>
            {
                entity.HasKey(e => e.RastId);

                entity.Property(e => e.RastId)
                    .HasColumnName("rast_id")
                    .HasMaxLength(50);

                entity.Property(e => e.RastDetail)
                    .HasColumnName("rast_detail")
                    .HasMaxLength(100);

                entity.Property(e => e.RastName)
                    .HasColumnName("rast_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.SId);

                entity.Property(e => e.SId)
                    .HasColumnName("s_id")
                    .HasMaxLength(50);

                entity.Property(e => e.SAddress)
                    .HasColumnName("s_address")
                    .HasMaxLength(100);

                entity.Property(e => e.SCloseTime)
                    .HasColumnName("s_close_time")
                    .HasColumnType("time(0)");

                entity.Property(e => e.SDistrict)
                    .HasColumnName("s_district")
                    .HasMaxLength(100);

                entity.Property(e => e.SLatitude)
                    .HasColumnName("s_latitude")
                    .HasMaxLength(100);

                entity.Property(e => e.SLongitude)
                    .HasColumnName("s_longitude")
                    .HasMaxLength(100);

                entity.Property(e => e.SName)
                    .HasColumnName("s_name")
                    .HasMaxLength(100);

                entity.Property(e => e.SOpenTime)
                    .HasColumnName("s_open_time")
                    .HasColumnType("time(0)");

                entity.Property(e => e.SProvince)
                    .HasColumnName("s_province")
                    .HasMaxLength(100);

                entity.Property(e => e.STel)
                    .HasColumnName("s_tel")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.SId)
                    .HasColumnName("s_id")
                    .HasMaxLength(50);

                entity.Property(e => e.TColumn)
                    .HasColumnName("t_column")
                    .HasMaxLength(50);

                entity.Property(e => e.TName)
                    .HasColumnName("t_name")
                    .HasMaxLength(100);

                entity.Property(e => e.TPrice).HasColumnName("t_price");

                entity.Property(e => e.TRow)
                    .HasColumnName("t_row")
                    .HasMaxLength(50);

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Table)
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("FK_Table_Store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
