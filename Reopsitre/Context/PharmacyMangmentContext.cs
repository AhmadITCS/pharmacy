using System;
using System.Collections.Generic;
using EntintyComponent.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace EntintyComponent;

public partial class PharmacyMangmentContext : DbContext
{
    public PharmacyMangmentContext()
    {
    }

    public PharmacyMangmentContext(DbContextOptions<PharmacyMangmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignUsersToRole> AssignUsersToRoles { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceMaster> InvoiceMasters { get; set; }

    public virtual DbSet<JobDescription> JobDescriptions { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineDepartment> MedicineDepartments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-08CBC1L;Database=PharmacyMangment;User Id=sa;Password=123;TrustServerCertificate=True;Integrated Security=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AssignUsersToRole>(entity =>
        {
            entity.HasKey(e => e.AssignUserToRoleId);

            entity.ToTable("AssignUsersToRole");

            entity.HasOne(d => d.Role).WithMany(p => p.AssignUsersToRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignUsersToRole_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.AssignUsersToRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssignUsersToRole_Users");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorException).HasMaxLength(50);
            entity.Property(e => e.ErrorMessage).HasMaxLength(50);
            entity.Property(e => e.ModuleName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.ErrorLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ErrorLog_ErrorLog");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceDetailsId);

            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.InvoiceMaster).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetails_InvoiceMaster");
        });

        modelBuilder.Entity<InvoiceMaster>(entity =>
        {
            entity.ToTable("InvoiceMaster");

            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.ReferenceNumber).HasMaxLength(50);
            entity.Property(e => e.TotalCostPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalSellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.ToTable("JobDescription");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.MedicineName).HasMaxLength(50);

            entity.HasOne(d => d.MedicineDepartment).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.MedicineDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_MedicineDepartment");
        });

        modelBuilder.Entity<MedicineDepartment>(entity =>
        {
            entity.ToTable("MedicineDepartment");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrginalQty).HasColumnName("OrginalQTY");
            entity.Property(e => e.RemaningQty).HasColumnName("RemaningQTY");
            entity.Property(e => e.SellingPriceAfterTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SellingPriceBeforeTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValueTex)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Value Tex");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Stores)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stores_Medicines");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Stores)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stores_Suppliers");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(50);
            entity.Property(e => e.SupplingArea).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(10);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.JobDescription).WithMany(p => p.Users)
                .HasForeignKey(d => d.JobDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_JobDescription");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
