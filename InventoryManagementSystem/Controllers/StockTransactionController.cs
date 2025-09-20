using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.DTOs;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionController : ControllerBase
    {
        private readonly InventoryContext _context;

        public StockTransactionController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTransactionDto>>> GetAll()
        {
            return await _context.StockTransactions
                .Select(st => new StockTransactionDto
                {
                    Id = st.Id,
                    ProductId = st.ProductId,
                    QuantityChanged = st.QuantityChanged,
                    TransactionType = st.TransactionType,
                    Date = st.Date
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockTransactionDto>> GetById(int id)
        {
            var st = await _context.StockTransactions.FindAsync(id);
            if (st == null) return NotFound();

            return new StockTransactionDto
            {
                Id = st.Id,
                ProductId = st.ProductId,
                QuantityChanged = st.QuantityChanged,
                TransactionType = st.TransactionType,
                Date = st.Date
            };
        }

        [HttpPost]
        public async Task<ActionResult<StockTransactionDto>> Create(StockTransactionDto dto)
        {
            var st = new StockTransaction
            {
                ProductId = dto.ProductId,
                QuantityChanged = dto.QuantityChanged,
                TransactionType = dto.TransactionType,
                Date = dto.Date
            };

            _context.StockTransactions.Add(st);
            await _context.SaveChangesAsync();

            dto.Id = st.Id;
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StockTransactionDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var st = await _context.StockTransactions.FindAsync(id);
            if (st == null) return NotFound();

            st.ProductId = dto.ProductId;
            st.QuantityChanged = dto.QuantityChanged;
            st.TransactionType = dto.TransactionType;
            st.Date = dto.Date;

            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var st = await _context.StockTransactions.FindAsync(id);
            if (st == null) return NotFound();

            _context.StockTransactions.Remove(st);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
