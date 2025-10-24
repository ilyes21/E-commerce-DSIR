using System.ComponentModel.DataAnnotations;

namespace E_commerce_DSIR.ViewModels.Identity
{
    public class GetRolesViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
