namespace InventoryManagementSystem.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }


        // Navigation property (one to many with products)
        public ICollection<Product>? Products { get; set; }

    }
}
