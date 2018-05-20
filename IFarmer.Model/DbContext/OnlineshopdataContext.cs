using Microsoft.EntityFrameworkCore;

namespace IFarmer.Model
{
    public partial class OnlineshopdataContext : DbContext
    {

        public OnlineshopdataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            base.OnModelCreating(modelBuilder);
        }
    }
}
