using System.ComponentModel.DataAnnotations;

namespace OneToManyCRUD.API.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
