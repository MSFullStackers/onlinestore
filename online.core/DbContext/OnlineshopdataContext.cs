
namespace online.core
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    [DiComponent(Lifetime = Lifetime.Singleton, Target = typeof(IOnlineshopdataContext), Key = "DiComponent")]
    public partial class OnlineshopdataContext : DbContext, IOnlineshopdataContext
    {
        public virtual DbSet<Products> Products { get; set; }

        public object GetList<t>()
        {
            return Products;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=.;User Id=userX;Password=;Database=onlineshopdata");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("char(250)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });
        }
    }
}
