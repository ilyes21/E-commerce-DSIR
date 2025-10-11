using System.ComponentModel.DataAnnotations;

namespace E_commerce_DSIR.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string CategoryName { get; set; }   
        public ICollection<Product>? Products { get; set; }
    }
}
