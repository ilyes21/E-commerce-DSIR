using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_DSIR.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50,MinimumLength=5)]
        public string Name { get; set; }
        [Required]
        [Display(Name="Prix en dinar :")]
        public float Price { get; set; }
        [Required]
        [Display(Name = "Quantité en unité :")]
        public int QteStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? clientFile { get; set; }
    }
}
