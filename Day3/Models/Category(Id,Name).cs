
using System.ComponentModel.DataAnnotations;

namespace Day3.Models
{
    public class Category_Id_Name_
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        public List<Product> products { get; set; }
    }
}
