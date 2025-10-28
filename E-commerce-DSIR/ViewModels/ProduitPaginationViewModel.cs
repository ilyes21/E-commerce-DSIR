using E_commerce_DSIR.Models;

namespace E_commerce_DSIR.ViewModels
{
    public class ProduitPaginationViewModel
    {
        public List<Product> Products { get; set; }
        public int PageActuelle{ get; set; }
        public  int TotalPages{ get; set; }
    }
}
