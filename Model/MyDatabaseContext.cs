using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

namespace DotNetCoreWebAPI
{
    public partial class MyDatabaseContext : DbContext, IDBContext
    {
        public MyDatabaseContext()
        {
        }

        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Demo> Demo { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

        //    modelBuilder.Entity<Demo>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.LastName)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<UserRole>(entity =>
        //    {
        //        entity.HasIndex(e => e.UserId);

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.UserRole)
        //            .HasForeignKey(d => d.RoleId);

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.UserRole)
        //            .HasForeignKey(d => d.UserId);
        //    });
        //}
    }
}
