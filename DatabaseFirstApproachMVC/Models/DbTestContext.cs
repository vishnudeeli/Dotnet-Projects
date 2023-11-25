using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproachMVC.Models;

public partial class DbTestContext : DbContext
{
    public DbTestContext()
    {
    }

    public DbTestContext(DbContextOptions<DbTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblAccountType> TblAccountTypes { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblDept> TblDepts { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblLogin> TblLogins { get; set; }

    public virtual DbSet<TblSkill> TblSkills { get; set; }

    public virtual DbSet<ZensarEmployee> ZensarEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(local); Database=db_test;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83FCD68E9E2");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Email, "UQ__clients__AB6E6164221647D9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__tblAccou__9F092CAA40F36E3D");

            entity.ToTable("tblAccount");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.AccBalance).HasColumnName("Acc_Balance");
            entity.Property(e => e.AccOpenDate)
                .HasColumnType("date")
                .HasColumnName("Acc_Open_Date");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer_ID");

            entity.HasOne(d => d.Account).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__tblAccoun__Accou__398D8EEE");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__tblAccoun__Custo__38996AB5");
        });

        modelBuilder.Entity<TblAccountType>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__tblAccou__B19E45C9E5E996E1");

            entity.ToTable("tblAccountType");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("Account_ID");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Account_Type");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.ToTable("tblCountry");

            entity.Property(e => e.Capital).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(20);
            entity.Property(e => e.Economy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblCusto__A4AE64B880E138A3");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
        });

        modelBuilder.Entity<TblDept>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__tblDept__014881AEAC412416");

            entity.ToTable("tblDept");

            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__tblEmplo__AF2D66D30C8ED628");

            entity.ToTable("tblEmployee");

            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__tblEmploy__DeptI__4222D4EF");
        });

        modelBuilder.Entity<TblLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblLogin");

            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSkill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__tblSkill__DFA091E79F76E621");

            entity.ToTable("tblSkills");

            entity.Property(e => e.SkillId).HasColumnName("SkillID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZensarEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__ZensarEm__7AD04FF1660A41DD");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SkillId).HasColumnName("SkillID");

            entity.HasOne(d => d.Skill).WithMany(p => p.ZensarEmployees)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("FK__ZensarEmp__Skill__76969D2E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
