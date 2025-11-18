using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetCategoryWithProductsAsync(int categoryId)
    {
        return await _dbSet
            .Include(c => c.Products.Where(p => p.IsActive))
            .FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
    {
        return await _dbSet
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryBySlugAsync(string slug)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);
    }
}
