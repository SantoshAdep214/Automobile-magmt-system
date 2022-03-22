using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class AMSDBContext : DbContext
    {
        public AMSDBContext()
        {
        }

        public AMSDBContext(DbContextOptions<AMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cardetail> Cardetails { get; set; }
        public virtual DbSet<Carsadmin> Carsadmins { get; set; }
        public virtual DbSet<Carservice> Carservices { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Orderbook> Orderbooks { get; set; }

      /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=AMSDB;Integrated Security=true;");
            }
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cardetail>(entity =>
            {
                entity.HasKey(e => e.Carno)
                    .HasName("pk_carno");

                entity.ToTable("cardetails");

                entity.HasIndex(e => e.Carmodel, "uk_carmodel")
                    .IsUnique();

                entity.Property(e => e.Carno).HasColumnName("carno");

                entity.Property(e => e.Carcolor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("carcolor");

                entity.Property(e => e.Carmileage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("carmileage");

                entity.Property(e => e.Carmodel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carmodel");

                entity.Property(e => e.Carprice).HasColumnName("carprice");

                entity.Property(e => e.Carquantity).HasColumnName("carquantity");

                entity.Property(e => e.Cartopspeed).HasColumnName("cartopspeed");
            });

            modelBuilder.Entity<Carsadmin>(entity =>
            {
                entity.HasKey(e => e.Adminid)
                    .HasName("pk_adminid");

                entity.ToTable("carsadmin");

                entity.Property(e => e.Adminid).HasColumnName("adminid");

                entity.Property(e => e.Adminname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminname");

                entity.Property(e => e.Adminpass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminpass");
            });

            modelBuilder.Entity<Carservice>(entity =>
            {
                entity.HasKey(e => e.Serviceid)
                    .HasName("pk_serviceid");

                entity.ToTable("carservice");

                entity.Property(e => e.Serviceid).HasColumnName("serviceid");

                entity.Property(e => e.Adddescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adddescription");

                entity.Property(e => e.Aptdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("aptdate");

                entity.Property(e => e.Carmodel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("carmodel");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carservices)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_svccustid");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Customeremail, "customeremailconstraint")
                    .IsUnique();

                entity.HasIndex(e => e.Customeremail, "unique_customeremail")
                    .IsUnique();

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Customeraddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customeraddress");

                entity.Property(e => e.Customeremail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customeremail");

                entity.Property(e => e.Customergender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customergender");

                entity.Property(e => e.Customermobno).HasColumnName("customermobno");

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customername");

                entity.Property(e => e.Customerpass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customerpass");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Employeeaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeaddress");

                entity.Property(e => e.Employeeemail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("employeeemail");

                entity.Property(e => e.Employeemobno).HasColumnName("employeemobno");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeename");

                entity.Property(e => e.Employeepass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("employeepass");
            });

            modelBuilder.Entity<Orderbook>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("pk_orderid");

                entity.ToTable("orderbook");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Billamount).HasColumnName("billamount");

                entity.Property(e => e.Carno).HasColumnName("carno");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Orderdate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("orderdate");

                entity.Property(e => e.Productname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.HasOne(d => d.CarnoNavigation)
                    .WithMany(p => p.Orderbooks)
                    .HasForeignKey(d => d.Carno)
                    .HasConstraintName("fk_carno");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orderbooks)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_customerid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
