using System.ComponentModel.DataAnnotations;

namespace OneToManyCRUD.Business.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
