
using E_commerce_DSIR.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace E_commerce_DSIR.Models.Repositories
{
    public class ProductRepository : IProductRepository

    {
        readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Product p = context.Products.Find(Id);
            if (p != null)
            {
                context.Products.Remove(p);
                context.SaveChanges();
            }
        }

        public IList<Product> FindByName(string name)
        {
            return context.Products
                .Where(p => p.Name.Contains(name)|| p.Category.CategoryName.Contains(name))
                .Include(p => p.Category)
                .ToList();
        }

        public IList<Product> GetAll()
        {
            return context.Products.OrderBy(x => x.Name).Include(p => p.Category).ToList();
        }

        public Product GetById(int Id)
        {
            return context.Products.Include(p => p.Category).SingleOrDefault(p => p.ProductId == Id);
        }

        public IList<Product> GetProductsByCategID(int? CategId)
        {
            return context.Products
                .Where(p => p.CategoryId.Equals(CategId))
                .OrderBy(p => p.ProductId)
                .Include(p => p.Category)
                .ToList();
        }

        public Product Update(Product p)
        {
            Product p1 = context.Products.Find(p.ProductId);
            if (p1 != null)
            {
                p1.Name = p.Name;
                p1.Price = p.Price;
                p1.QteStock = p.QteStock;
                p1.CategoryId = p.CategoryId;
                p1.Image = p.Image;
                context.SaveChanges();
            }
            return p1;
        }
    }
}
