namespace InventoryManagementSystem.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }   // Only for reading
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Foreign keys
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
