using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreWebAPI
{
    public partial class MySecondDatabaseContext : DbContext
    {
        public MySecondDatabaseContext()
        {
        }

        public MySecondDatabaseContext(DbContextOptions<MySecondDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GasStations> GasStations { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
    
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

        //    modelBuilder.Entity<GasStations>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.Brannd)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<OrderProducts>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();
        //    });

        //    modelBuilder.Entity<Orders>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();
        //    });
        //}
    }
}
