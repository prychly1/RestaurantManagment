using System.ComponentModel.DataAnnotations;

namespace SomeWarehouse.Models
{
    public class CreateWarehouseDto
    {
        [Required]
        [MaxLength(30)]


        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        
        [Required]
        [MaxLength(30)]
        public int numberOfShelf { get; set; }
    }
}
