using InventoryAPI.Data;
using InventoryManagementSystem.Models.DTOs;
using InventoryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class StockTransactionService
    {
        private readonly InventoryContext _context;

        public StockTransactionService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<List<StockTransactionDto>> GetAllAsync()
        {
            return await _context.StockTransactions
                .Select(st => new StockTransactionDto
                {
                    Id = st.Id,
                    ProductId = st.ProductId,
                    QuantityChanged = st.QuantityChanged,
                    TransactionType = st.TransactionType,
                    Date = st.Date
                })
                .ToListAsync();
        }

        public async Task<StockTransactionDto?> GetByIdAsync(int id)
        {
            return await _context.StockTransactions
                .Where(st => st.Id == id)
                .Select(st => new StockTransactionDto
                {
                    Id = st.Id,
                    ProductId = st.ProductId,
                    QuantityChanged = st.QuantityChanged,
                    TransactionType = st.TransactionType,
                    Date = st.Date
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StockTransactionDto> AddAsync(StockTransactionDto dto)
        {
            var transaction = new StockTransaction
            {
                ProductId = dto.ProductId,
                QuantityChanged = dto.QuantityChanged,
                TransactionType = dto.TransactionType,
                Date = dto.Date
            };

            _context.StockTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            dto.Id = transaction.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.StockTransactions.FindAsync(id);
            if (transaction == null) return false;

            _context.StockTransactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
