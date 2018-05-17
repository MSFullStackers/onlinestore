using Microsoft.EntityFrameworkCore;

namespace Online.Model
{
    public partial class OnlineshopdataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=den1.mysql4.gear.host;User Id=onlineshopdata;Password=Vignesh_070;Database=onlineshopdata");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Products");
            base.OnModelCreating(modelBuilder);
        }
    }
}
