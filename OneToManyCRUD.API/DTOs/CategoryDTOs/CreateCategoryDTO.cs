using System.ComponentModel.DataAnnotations;

namespace OneToManyCRUD.API.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
