using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
   
        public class ApplicationDbContext : DbContext
        {


            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public DbSet<Product> products { get; set; }
            public DbSet<ProductDetails> productsDetails { get; set; }

        }
    }



