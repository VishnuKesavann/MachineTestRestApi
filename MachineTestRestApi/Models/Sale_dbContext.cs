using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MachineTestRestApi.Models
{
    public partial class Sale_dbContext : DbContext
    {
        public Sale_dbContext()
        {
        }

        public Sale_dbContext(DbContextOptions<Sale_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = VISHNU\\SQLEXPRESS; Initial Catalog = Sale_db; Integrated security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__Purchase__904BC20E8B939485");

                entity.Property(e => e.OId)
                    .HasColumnName("o_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseOrderNumber)
                    .HasColumnName("purchase_order_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VId).HasColumnName("v_id");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__PurchaseOr__c_id__2B3F6F97");

                entity.HasOne(d => d.V)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.VId)
                    .HasConstraintName("FK__PurchaseOr__v_id__2C3393D0");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__tbl_Cust__213EE774EAFC0A9D");

                entity.ToTable("tbl_Customer");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.TblCustomer)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__tbl_Custom__l_id__267ABA7A");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__tbl_Logi__A7C7B6F8E0F57203");

                entity.ToTable("tbl_Login");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("PK__tbl_Vend__AD3D8441D9BF718A");

                entity.ToTable("tbl_Vendor");

                entity.Property(e => e.VId)
                    .HasColumnName("v_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasColumnName("vendor_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
