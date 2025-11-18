using LaptopShopWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopWeb.DAL.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .Where(p => p.IsFeatured && p.IsActive)
            .OrderByDescending(p => p.ViewCount)
            .Take(count)
            .ToListAsync();
    }

    public async Task<Product?> GetProductWithVariantsAsync(int productId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants.Where(v => v.IsActive))
            .Include(p => p.ProductImages)
            .Include(p => p.Reviews.Where(r => r.IsApproved))
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<Product?> GetProductWithCategoryAsync(int productId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
    {
        var lowerKeyword = keyword.ToLower();
        
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .Where(p => p.IsActive && (
                p.Name.ToLower().Contains(lowerKeyword) ||
                p.Brand!.ToLower().Contains(lowerKeyword) ||
                p.Description!.ToLower().Contains(lowerKeyword)
            ))
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetActiveProductsAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .Where(p => p.IsActive)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithVariantsAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .Where(p => p.HasVariants && p.IsActive)
            .ToListAsync();
    }
}
