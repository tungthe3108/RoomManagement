using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RoomRentalManagementClassLibrary.Models;

public partial class RoomRetalManagementContext : DbContext
{
    public RoomRetalManagementContext()
    {
    }

    public RoomRetalManagementContext(DbContextOptions<RoomRetalManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<NumOfPerson> NumOfPeople { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomPrice> RoomPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyDB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Area");

            entity.Property(e => e.Area1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Area");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => new { e.ContractId, e.RoomId, e.CustomerId });

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ContractID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateOfExpiration).HasColumnType("date");
            entity.Property(e => e.DateOfHire).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Customer");

            entity.HasOne(d => d.Room).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Room");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Room).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Customer_Room");

            entity.HasMany(d => d.Rooms).WithMany(p => p.CustomersNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Customer_Room_Room"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Customer_Room_Customer"),
                    j =>
                    {
                        j.HasKey("CustomerId", "RoomId");
                        j.ToTable("Customer_Room");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("CustomerID");
                        j.IndexerProperty<int>("RoomId").HasColumnName("RoomID");
                    });
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Floor");

            entity.Property(e => e.Floor1).HasColumnName("Floor");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.RoomId, e.CustomerId });

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.InvoiceType)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Customer");

            entity.HasOne(d => d.Room).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Room");
        });

        modelBuilder.Entity<NumOfPerson>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NumOfPerson");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NumOfPerson1).HasColumnName("NumOfPerson");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.RoomName)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasMany(d => d.Customers1).WithMany(p => p.RoomsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "RoomCustomer",
                    r => r.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Room_Customer_Customer"),
                    l => l.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Room_Customer_Room"),
                    j =>
                    {
                        j.HasKey("RoomId", "CustomerId");
                        j.ToTable("Room_Customer");
                        j.IndexerProperty<int>("RoomId").HasColumnName("RoomID");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("CustomerID");
                    });
        });

        modelBuilder.Entity<RoomPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RoomPrice");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Price).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
