namespace OneToManyCRUD.API.DTOs.TagDTOs
{
    public class CreateTagDTO
    {
        public string Name { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
    }
}
