using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LoanSystem.Infrastructure.Data
{
    public partial class LoanSystemContext : DbContext
    {
        public LoanSystemContext()
        {
        }

        public LoanSystemContext(DbContextOptions<LoanSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<User> User { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.LoanApplication).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_User");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Loan");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
