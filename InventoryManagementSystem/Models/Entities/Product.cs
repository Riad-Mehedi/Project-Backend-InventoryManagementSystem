namespace InventoryManagementSystem.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        // Foreign Keys
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }


        // Navigation properties
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }


        // Stock Transactions
        public ICollection<StockTransaction>? StockTransactions { get; set; }
    }
}
