using Gadget.Data.Data.CMS;
using Gadget.Data.Data.Shop;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gadget.Data.Data
{
    public partial class GadgetIntranetContext : IdentityDbContext
    {

        public GadgetIntranetContext()
        {
         
        }

        public GadgetIntranetContext(DbContextOptions<GadgetIntranetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Producers> Producerss { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<Page> Page { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=10.0.0.7,1433 ;User ID=SA;Password= VeryStr0ngP@ssw0rd; Database=GadgetDb;TrustServerCertificate=True;MultipleActiveResultSets=true");

        }
    }
}