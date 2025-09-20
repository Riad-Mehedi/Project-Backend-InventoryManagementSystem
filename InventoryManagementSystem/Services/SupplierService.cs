using InventoryAPI.Data;
using InventoryManagementSystem.Models.DTOs;
using InventoryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class SupplierService
    {
        private readonly InventoryContext _context;

        public SupplierService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactInfo = s.ContactInfo
                })
                .ToListAsync();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            return await _context.Suppliers
                .Where(s => s.Id == id)
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContactInfo = s.ContactInfo
                })
                .FirstOrDefaultAsync();
        }

        public async Task<SupplierDto> AddAsync(SupplierDto dto)
        {
            var supplier = new Supplier
            {
                Name = dto.Name,
                ContactInfo = dto.ContactInfo
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            dto.Id = supplier.Id;
            return dto;
        }

        public async Task<SupplierDto?> UpdateAsync(int id, SupplierDto dto)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return null;

            supplier.Name = dto.Name;
            supplier.ContactInfo = dto.ContactInfo;

            await _context.SaveChangesAsync();

            dto.Id = supplier.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null) return false;

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

