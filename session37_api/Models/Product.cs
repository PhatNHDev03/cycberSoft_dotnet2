using System.ComponentModel.DataAnnotations;
namespace session37_api.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 999999, ErrorMessage ="Price must be between 0 and 999999")]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}