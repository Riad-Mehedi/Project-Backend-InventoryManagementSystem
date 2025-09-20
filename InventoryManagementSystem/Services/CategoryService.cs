using InventoryAPI.Data;
using InventoryManagementSystem.Models.DTOs;
using InventoryManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class CategoryService
    {
        private readonly InventoryContext _context;

        public CategoryService(InventoryContext context)
        {
            _context = context;
        }

        // Get all categories
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }

        // Get category by Id
        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefaultAsync();
        }

        // Create category
        public async Task<CategoryDto> AddAsync(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            dto.Id = category.Id;
            return dto;
        }

        // Update category
        public async Task<CategoryDto?> UpdateAsync(int id, CategoryDto dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            category.Name = dto.Name;
            category.Description = dto.Description;

            await _context.SaveChangesAsync();

            dto.Id = category.Id;
            return dto;
        }

        // Delete category
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
