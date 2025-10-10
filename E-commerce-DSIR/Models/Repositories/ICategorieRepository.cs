namespace E_commerce_DSIR.Models.Repositories
{
    public interface ICategorieRepository
    {
        Category GetById(int Id);
        IList<Category> GetAll();
        void Add(Category t);
        Category Update(Category t);
        void Delete(int Id);
    }
}
