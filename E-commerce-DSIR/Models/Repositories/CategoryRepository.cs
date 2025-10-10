
using E_commerce_DSIR.Data;

namespace E_commerce_DSIR.Models.Repositories
{
    public class CategoryRepository : ICategorieRepository
    {
        readonly AppDbContext context;
        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Category t)
        {
            context.Categories.Add(t);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Category c = context.Categories.Find(Id);
            if (c != null)
            {
                context.Categories.Remove(c);
                context.SaveChanges();
            }
        }

        public IList<Category> GetAll()
        {
            return context.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        public Category GetById(int Id)
        {
            return context.Categories.Find(Id);
        }

        public Category Update(Category cat)
        {
            Category c = context.Categories.Find(cat.CategoryId);
            if (c != null)
            {
                c.CategoryName = cat.CategoryName;
                context.SaveChanges();
            }
            return c;
        }
    }
}
