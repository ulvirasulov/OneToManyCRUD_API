using System.ComponentModel.DataAnnotations;

namespace OneToManyCRUD.API.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
