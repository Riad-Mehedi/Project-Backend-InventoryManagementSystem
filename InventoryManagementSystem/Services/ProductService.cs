using InventoryAPI.Data;
using InventoryManagementSystem.Models.DTOs;
using InventoryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductService
    {
        private readonly InventoryContext _context;

        public ProductService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllAsync()
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
                })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProductDto> AddAsync(ProductDto dto)
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
            return dto;
        }

        public async Task<ProductDto?> UpdateAsync(int id, ProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;

            await _context.SaveChangesAsync();

            dto.Id = product.Id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
