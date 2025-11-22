
using E_commerce_DSIR.Data;

namespace E_commerce_DSIR.Models.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        readonly AppDbContext context;
        public StoreRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Store t)
        {
            context.Stores.Add(t);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Store c = context.Stores.Find(Id);
            if (c != null)
            {
                context.Stores.Remove(c);
                context.SaveChanges();
            }
        }

        public IList<Store> GetAll()
        {
            return context.Stores.OrderBy(c => c.Name).ToList();
        }

        public Store GetById(int Id)
        {
            return context.Stores.Find(Id);
        }

        public Store Update(Store St)
        {
            Store s = context.Stores.Find(St.Id);
            if (s != null)
            {
                s.Name = St.Name;
                s.Address = St.Address;
                s.PhoneNumber = St.PhoneNumber;
                s.Long = St.Long;
                s.Lat = St.Lat;
                context.SaveChanges();
            }
            return s;
        }
    }
}
