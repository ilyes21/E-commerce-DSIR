using E_commerce_DSIR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_DSIR.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<E_commerce_DSIR.Models.Product> Products { get; set; }
        public DbSet<E_commerce_DSIR.Models.Category> Categories { get; set; }
        public DbSet<E_commerce_DSIR.Models.Panier> Paniers { get; set; }
        public DbSet<E_commerce_DSIR.Models.Commande> Commandes { get; set; }
        public DbSet<E_commerce_DSIR.Models.Order> Orders { get; set; }
        public DbSet<E_commerce_DSIR.Models.OrderItem> OrderItems { get; set; }
        public DbSet<E_commerce_DSIR.Models.Store> Stores { get; set; }
    }
}
