namespace E_commerce_DSIR.Models.Repositories
{
    public interface IStoreRepository
    {
        Store GetById(int Id);
        IList<Store> GetAll();
        void Add(Store t);
        Store Update(Store t);
        void Delete(int Id);
    }
}
