using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vizsgaremek.Models;

public partial class VizsgaremekContext : DbContext
{
    public VizsgaremekContext()
    {
    }

    public VizsgaremekContext(DbContextOptions<VizsgaremekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=vizsgaremek;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "CategoryName").IsUnique();

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.RequesterId, "RequesterID");

            entity.HasIndex(e => e.ServiceId, "ServiceID");

            entity.Property(e => e.RequestId)
                .HasColumnType("int(11)")
                .HasColumnName("RequestID");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.RequesterId)
                .HasColumnType("int(11)")
                .HasColumnName("RequesterID");
            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("ServiceID");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'''Pending'''")
                .HasColumnType("enum('Pending','Approved','Completed','Rejected')");

            entity.HasOne(d => d.Requester).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequesterId)
                .HasConstraintName("requests_ibfk_1");

            entity.HasOne(d => d.Service).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("requests_ibfk_2");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.UserId, "UserID");

            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("ServiceID");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ServiceName).HasMaxLength(100);
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Services)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("services_ibfk_1");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.ReceiverId, "ReceiverID");

            entity.HasIndex(e => e.SenderId, "SenderID");

            entity.HasIndex(e => e.ServiceId, "ServiceID");

            entity.Property(e => e.TransactionId)
                .HasColumnType("int(11)")
                .HasColumnName("TransactionID");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
            entity.Property(e => e.ReceiverId)
                .HasColumnType("int(11)")
                .HasColumnName("ReceiverID");
            entity.Property(e => e.SenderId)
                .HasColumnType("int(11)")
                .HasColumnName("SenderID");
            entity.Property(e => e.ServiceId)
                .HasColumnType("int(11)")
                .HasColumnName("ServiceID");
            entity.Property(e => e.TimeAmount).HasPrecision(10);
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Receiver).WithMany(p => p.TransactionReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("transactions_ibfk_2");

            entity.HasOne(d => d.Sender).WithMany(p => p.TransactionSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("transactions_ibfk_1");

            entity.HasOne(d => d.Service).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("transactions_ibfk_3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.PrivilegeId, "PrivilegeID");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PrivilegeId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("PrivilegeID");
            entity.Property(e => e.TimeBalance)
                .HasPrecision(10)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
