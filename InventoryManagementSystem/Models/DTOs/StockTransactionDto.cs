namespace InventoryManagementSystem.Models.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }   // Only for reading
        public int ProductId { get; set; }
        public int QuantityChanged { get; set; }
        public string TransactionType { get; set; } = string.Empty; // purchase or sale
       // public DateTime? Date { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

    }
}
