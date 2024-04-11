using BackendForFrontend.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category1>> GetAllCategoriesAsync()
        {
            return await _context.Categories1.ToListAsync();
        }

        public async Task<Category1> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories1.FindAsync(id);
        }

        public async Task CreateCategoryAsync(Category1 category)
        {
            _context.Categories1.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category1 category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category1 category)
        {
            _context.Categories1.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
