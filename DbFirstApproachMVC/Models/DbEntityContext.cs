using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproachMVC.Models;

public partial class DbEntityContext : DbContext
{
    public DbEntityContext()
    {
    }

    public DbEntityContext(DbContextOptions<DbEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(local); Database=db_entity;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCount__3214EC07A03BF56C");

            entity.ToTable("tblCountries");

            entity.Property(e => e.Captital)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Currency)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
