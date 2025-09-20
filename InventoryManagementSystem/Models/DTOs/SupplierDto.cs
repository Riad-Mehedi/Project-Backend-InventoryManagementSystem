namespace InventoryManagementSystem.Models.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }   // Only for reading
        public string Name { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
    }
}
