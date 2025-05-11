using System.ComponentModel.DataAnnotations;
namespace session40_52.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 100000000, ErrorMessage = "Price must be between 0 and 100000000")]
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        // public string Thumbnail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}