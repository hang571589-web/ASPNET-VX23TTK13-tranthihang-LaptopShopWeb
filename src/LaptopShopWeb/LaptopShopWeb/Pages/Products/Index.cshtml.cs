using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Services;

namespace LaptopShopWeb.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;

    private static readonly List<(string Key, string Label)> CategoryDefinitions = new()
    {
        ("all", "All"),
        ("gaming", "Gaming Laptop"),
        ("business", "Business Laptop"),
        ("workstation", "Workstation"),
        ("ultrabook", "Ultrabook")
    };

    private static readonly Dictionary<string, string[]> CategoryNameMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["gaming"] = new[] { "Laptop Gaming" },
        ["business"] = new[] { "Laptop Văn Phòng" },
        ["workstation"] = new[] { "Laptop Đồ Họa" },
        ["ultrabook"] = new[] { "Laptop Mỏng Nhẹ" }
    };

    private static readonly List<(string Key, string Label)> BrandDefinitions = new()
    {
        ("dell", "Dell"),
        ("hp", "HP"),
        ("lenovo", "Lenovo"),
        ("asus", "Asus"),
        ("msi", "MSI"),
        ("acer", "Acer"),
        ("apple", "Apple")
    };

    private static readonly Dictionary<string, string> BrandLabelMap = BrandDefinitions
        .ToDictionary(item => item.Key, item => item.Label, StringComparer.OrdinalIgnoreCase);

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public List<ProductDto> Products { get; set; } = new();
    public List<CheckboxFilterOption> CategoryFilters { get; private set; } = new();
    public List<CheckboxFilterOption> BrandFilters { get; private set; } = new();
    public List<PriceRangeOption> PriceRanges { get; } = new()
    {
        new PriceRangeOption { Key = "all", Label = "Tất cả" },
        new PriceRangeOption { Key = "under-15", Label = "Dưới 15 triệu", Max = 15_000_000m },
        new PriceRangeOption { Key = "15-25", Label = "15-25 triệu", Min = 15_000_000m, Max = 25_000_000m },
        new PriceRangeOption { Key = "25-35", Label = "25-35 triệu", Min = 25_000_000m, Max = 35_000_000m },
        new PriceRangeOption { Key = "over-35", Label = "Trên 35 triệu", Min = 35_000_000m }
    };
    public List<SelectListItem> SortOptions { get; } = new()
    {
        new SelectListItem { Value = "latest", Text = "Mới nhất" },
        new SelectListItem { Value = "price-asc", Text = "Giá: Thấp → Cao" },
        new SelectListItem { Value = "price-desc", Text = "Giá: Cao → Thấp" },
        new SelectListItem { Value = "name-asc", Text = "Tên: A-Z" }
    };

    [BindProperty(SupportsGet = true)]
    public List<string> SelectedCategories { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public List<string> SelectedBrands { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? PriceRange { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SortOption { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public async Task OnGetAsync()
    {
        SelectedCategories ??= new List<string>();
        SelectedBrands ??= new List<string>();
        PriceRange = string.IsNullOrWhiteSpace(PriceRange) ? "all" : PriceRange;
        SortOption = string.IsNullOrWhiteSpace(SortOption) ? "latest" : SortOption;

        var allProducts = await _productService.GetActiveProductsAsync();

        BuildCategoryFilters(allProducts);
        BuildBrandFilters(allProducts);

        var filteredProducts = ApplyFilters(allProducts);
        Products = ApplySorting(filteredProducts).ToList();
    }

    public bool IsCategoryChecked(string key)
    {
        if (string.Equals(key, "all", StringComparison.OrdinalIgnoreCase))
        {
            return !SelectedCategories.Any();
        }

        return SelectedCategories.Any(selected => string.Equals(selected, key, StringComparison.OrdinalIgnoreCase));
    }

    public bool IsBrandChecked(string key) =>
        SelectedBrands.Any(selected => string.Equals(selected, key, StringComparison.OrdinalIgnoreCase));

    public bool IsPriceRangeSelected(string key) =>
        string.Equals(PriceRange, key, StringComparison.OrdinalIgnoreCase);

    private void BuildCategoryFilters(IEnumerable<ProductDto> products)
    {
        var options = new List<CheckboxFilterOption>();

        foreach (var (key, label) in CategoryDefinitions)
        {
            int count;

            if (string.Equals(key, "all", StringComparison.OrdinalIgnoreCase))
            {
                count = products.Count();
            }
            else
            {
                if (!CategoryNameMap.TryGetValue(key, out var names))
                {
                    continue;
                }

                var comparableNames = new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);
                count = products.Count(product => comparableNames.Contains(product.CategoryName));
            }

            options.Add(new CheckboxFilterOption
            {
                Key = key,
                Label = label,
                Count = count
            });
        }

        CategoryFilters = options;
    }

    private void BuildBrandFilters(IEnumerable<ProductDto> products)
    {
        var options = new List<CheckboxFilterOption>();

        foreach (var (key, label) in BrandDefinitions)
        {
            var count = products.Count(product =>
                !string.IsNullOrEmpty(product.Brand) &&
                product.Brand.Equals(label, StringComparison.OrdinalIgnoreCase));

            options.Add(new CheckboxFilterOption
            {
                Key = key,
                Label = label,
                Count = count
            });
        }

        BrandFilters = options;
    }

    private IEnumerable<ProductDto> ApplyFilters(IEnumerable<ProductDto> products)
    {
        var filtered = products;

        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var keyword = SearchTerm.Trim().ToLower();
            filtered = filtered.Where(product =>
                product.Name.ToLower().Contains(keyword) ||
                (!string.IsNullOrEmpty(product.Description) && product.Description.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(product.Brand) && product.Brand.ToLower().Contains(keyword)));
        }

        var normalizedCategories = SelectedCategories
            .Where(key => !string.Equals(key, "all", StringComparison.OrdinalIgnoreCase))
            .Where(CategoryNameMap.ContainsKey)
            .SelectMany(key => CategoryNameMap[key])
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (normalizedCategories.Any())
        {
            filtered = filtered.Where(product => normalizedCategories.Contains(product.CategoryName));
        }

        var normalizedBrands = SelectedBrands
            .Where(BrandLabelMap.ContainsKey)
            .Select(key => BrandLabelMap[key])
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (normalizedBrands.Any())
        {
            filtered = filtered.Where(product =>
                !string.IsNullOrEmpty(product.Brand) && normalizedBrands.Contains(product.Brand));
        }

        var range = PriceRanges.FirstOrDefault(option =>
            option.Key.Equals(PriceRange ?? "all", StringComparison.OrdinalIgnoreCase));

        if (range != null && !string.Equals(range.Key, "all", StringComparison.OrdinalIgnoreCase))
        {
            if (range.Min.HasValue)
            {
                filtered = filtered.Where(product => product.Price >= range.Min.Value);
            }

            if (range.Max.HasValue)
            {
                filtered = filtered.Where(product => product.Price < range.Max.Value);
            }
        }

        return filtered;
    }

    private IEnumerable<ProductDto> ApplySorting(IEnumerable<ProductDto> products)
    {
        return SortOption switch
        {
            "price-asc" => products.OrderBy(product => product.Price),
            "price-desc" => products.OrderByDescending(product => product.Price),
            "name-asc" => products.OrderBy(product => product.Name),
            _ => products.OrderByDescending(product => product.CreatedAt)
        };
    }

    public class CheckboxFilterOption
    {
        public string Key { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class PriceRangeOption
    {
        public string Key { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
    }
}
