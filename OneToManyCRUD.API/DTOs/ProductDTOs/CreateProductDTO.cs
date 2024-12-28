using System.ComponentModel.DataAnnotations;

namespace OneToManyCRUD.API.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = new List<int>();
    }
}
