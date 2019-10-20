using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeInventario.Models;

namespace SistemaDeInventario.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Buy> Buys { get; set; }

        public DbSet<Sell> Sells { get; set; }

        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<BranchProduct>()
                .HasKey(bp => new { bp.BranchID, bp.ProductID });

            builder.Entity<BranchProduct>()
                .HasOne(bp => bp.Branch)
                .WithMany(bp => bp.Products)
                .HasForeignKey(bp => bp.BranchID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<BranchProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(bp => bp.Branches)
                .HasForeignKey(bp => bp.ProductID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryID, cp.ProductID });

            builder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(cp => cp.Products)
                .HasForeignKey(cp => cp.CategoryID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(cp => cp.Categories)
                .HasForeignKey(cp => cp.ProductID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<ProviderProduct>()
                .HasKey(pp => new { pp.ProviderID, pp.ProductID });

            builder.Entity<ProviderProduct>()
                .HasOne(pp => pp.Provider)
                .WithMany(pp => pp.Products)
                .HasForeignKey(pp => pp.ProviderID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<ProviderProduct>()
                .HasOne(pp => pp.Product)
                .WithMany(pp => pp.Providers)
                .HasForeignKey(pp => pp.ProductID)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<SistemaDeInventario.Models.Branch> Branch { get; set; }

        public DbSet<SistemaDeInventario.Models.BranchProduct> BranchProduct { get; set; }

        public DbSet<SistemaDeInventario.Models.CategoryProduct> CategoryProduct { get; set; }

        public DbSet<SistemaDeInventario.Models.ProviderProduct> ProviderProduct { get; set; }
    }
}
