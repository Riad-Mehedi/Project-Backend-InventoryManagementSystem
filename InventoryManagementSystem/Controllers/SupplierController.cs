using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.DTOs;

namespace InventoryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly InventoryContext _context;

        public SupplierController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
        {
            return await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactInfo = s.ContactInfo
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            return new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInfo = supplier.ContactInfo
            };
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Create(SupplierDto dto)
        {
            var supplier = new Supplier
            {
                Name = dto.Name,
                ContactInfo = dto.ContactInfo
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            dto.Id = supplier.Id;
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            supplier.Name = dto.Name;
            supplier.ContactInfo = dto.ContactInfo;

            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return NotFound();

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
