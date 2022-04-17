using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project.Model.EF
{
    public partial class ZaSaStored : DbContext
    {
        public ZaSaStored()
            : base("name=ZaSaStored")
        {
        }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<ACCOUNT> ACCOUNT { get; set; }
        public virtual DbSet<CT_DON_HANG> CT_DON_HANG { get; set; }
        public virtual DbSet<CT_KM> CT_KM { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<KHUYEN_MAI> KHUYEN_MAI { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<PHIEU_NHAN> PHIEU_NHAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.DT_GH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.CT_DON_HANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.CT_KM)
                .WithRequired(e => e.KHACH_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.DON_HANG)
                .WithRequired(e => e.KHACH_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYEN_MAI>()
                .Property(e => e.MAKM)
                .IsUnicode(false);

            modelBuilder.Entity<KHUYEN_MAI>()
                .HasMany(e => e.CT_KM)
                .WithRequired(e => e.KHUYEN_MAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SAN_PHAM>()
                .Property(e => e.DON_GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SAN_PHAM>()
                .HasMany(e => e.CT_DON_HANG)
                .WithRequired(e => e.SAN_PHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
