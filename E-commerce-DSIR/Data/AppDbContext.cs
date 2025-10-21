using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_DSIR.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<E_commerce_DSIR.Models.Product> Products { get; set; }
        public DbSet<E_commerce_DSIR.Models.Category> Categories { get; set; }
    }
}
