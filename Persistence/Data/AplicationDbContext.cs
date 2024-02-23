using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.Models;

namespace Persistence.Data
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext()
        {
        }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovedAuthorization> ApprovedAuthorizations { get; set; } = null!;
        public virtual DbSet<AuthorizationRequest> AuthorizationRequests { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=GeoPagos_Database;Trusted_Connection=True; Encrypt=False;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovedAuthorization>(entity =>
            {

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("approval_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ApprovedAuthorizations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ApprovedA__clien__208CD6FA");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ApprovedAuthorizations)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ApprovedA__reque__1F98B2C1");
            });

            modelBuilder.Entity<AuthorizationRequest>(entity =>
            {

                entity.HasKey(e => e.Id)
                   .HasName("PK_AuthorizationRequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.AuthorizationType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("authorization_type");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("request_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.AuthorizationRequests)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Authoriza__clien__1BC821DD");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("client_type");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reports__ClientI__29221CFB");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
