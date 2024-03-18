using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspApiCoreapi.Models
{
    public partial class tempdbContext : DbContext
    {
        public tempdbContext()
        {
        }

        public tempdbContext(DbContextOptions<tempdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Blood_Group");

                entity.Property(e => e.ContactNumber)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Contact_Number");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("F_Name");

                entity.Property(e => e.LName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("L_Name");

                entity.Property(e => e.Salary).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
