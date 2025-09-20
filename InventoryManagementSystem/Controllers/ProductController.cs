using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.DTOs;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ProductController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            dto.Id = product.Id;
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;

            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
