using E_commerce_DSIR.Data;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_DSIR.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Order o)
        {
            context.Orders.Add(o);
            context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return context.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
        }
    }
}
