using ApplicationCore.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Infrastructure.Migrations
{
    public class EveniDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public EveniDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Order_Detail> Order_Details{ get; set; }

        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
                .HasOne<ApplicationUser>(p => p.ApplicationUser)
                .WithMany(a => a.Products);
            builder.Entity<Order>()
                .HasOne<Order_Detail>(od => od.Order_Detail)
                .WithMany(o => o.Orders)
                .IsRequired();
            builder.Entity<Image>()
                .HasOne<Product>(p => p.Product)
                .WithMany(i => i.Images)
                .IsRequired();
            

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
       
    }
}
