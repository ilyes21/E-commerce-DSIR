namespace E_commerce_DSIR.Models.Repositories
{
    public interface IOrderRepository
    {
        Order GetById(int Id);
        void Add(Order o);
    }
}
