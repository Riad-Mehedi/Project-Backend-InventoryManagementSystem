using System.Net.Http.Headers;

namespace InventoryManagementSystem.Models.Entities
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityChanged { get; set; }
        public string TransactionType { get; set; } = string.Empty; // purchase or sale
        public DateTime Date { get; set; } = DateTime.UtcNow;
        
        
        // Navigation property
        public Product? Product { get; set; }

    }
}
