namespace InventoryManagementSystem.Models.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }


        // Navigation property (one to many with products)
        public ICollection<Product>? Products { get; set; }
    }
}
