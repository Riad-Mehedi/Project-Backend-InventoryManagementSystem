namespace InventoryManagementSystem.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }   // Only for reading
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

