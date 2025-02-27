using System;
using System.Collections.Generic;
using basicCarDealership_prep.data.Models;
using Microsoft.EntityFrameworkCore;

namespace basicCarDealership_prep.data;

public partial class ITrellisCarDealershipContext : DbContext
{
    public ITrellisCarDealershipContext()
    {
    }

    public ITrellisCarDealershipContext(DbContextOptions<ITrellisCarDealershipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Make> Makes { get; set; }

    public virtual DbSet<VehicleSearchViewModel> Vehicles { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=PCSONIC;Database=iTrellisCarDealership;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0340E815513E9");

            entity.Property(e => e.CarId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CarID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.MakeId).HasColumnName("MakeID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cars__ColorID__412EB0B6");

            entity.HasOne(d => d.Make).WithMany(p => p.Cars)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cars__MakeID__403A8C7D");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7676D269B29A5");

            entity.ToTable("Color");

            entity.HasIndex(e => e.ColorName, "UQ__Color__C71A5A7B9CB4F566").IsUnique();

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ColorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasKey(e => e.MakeId).HasName("PK__Make__43646F315AA55C80");

            entity.ToTable("Make");

            entity.HasIndex(e => e.MakeName, "UQ__Make__C6852DFEFD1CC875").IsUnique();

            entity.Property(e => e.MakeId).HasColumnName("MakeID");
            entity.Property(e => e.MakeName).HasMaxLength(50);
        });

        modelBuilder.Entity<VehicleSearchViewModel>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
