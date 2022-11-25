using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoUnitTest.Models;

public partial class OneTableContext : DbContext
{
    public OneTableContext()
    {
    }

    public OneTableContext(DbContextOptions<OneTableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server = MOBACK;Database=OneTable;Integrated Security=true;TrustServerCertificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE204575AF238B0");

            entity.ToTable("Salary");

            entity.Property(e => e.SalaryId).ValueGeneratedNever();
            entity.Property(e => e.Salary1).HasColumnName("Salary");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Salary__userId__267ABA7A");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblUser__3214EC070C1CC8C3");

            entity.ToTable("TblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
