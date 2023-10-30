using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Task_2.Entities
{
    public class Product
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DisplayName("Category")]
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
        [DisplayName("Discount")]
        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }
        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [DisplayName("Image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImagePath { get; set; }
    }
}
