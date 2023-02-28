using System;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
  {
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
      _context = context;
    }

    public async  Task<ServiceResponse<List<Product>>> GetProductAsync()
    {
      var response = new ServiceResponse<List<Product>>
      {
        Data = await _context.Products.Include(v => v.Variants).ToListAsync()
      };

      return response;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int produtcId)
    {
      var response = new ServiceResponse<Product>();
      var product = await _context.Products
        .Include(v => v.Variants)
        .ThenInclude(t => t.ProductType)
        .FirstOrDefaultAsync(p => p.Id == produtcId);
      if(product == null) 
      {
        response.Success = true;
        response.Message = "Sorry, but this product";
      }
      response.Data = product;

      return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
    {
      var response = new ServiceResponse<List<Product>>
      {
        Data = await _context.Products
        .Where(p => p.Category.Url.ToLower()
        .Equals(categoryUrl.ToLower()))
        .Include(v => v.Variants)
        .ToListAsync()
      };

      return response;
    }

    public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
    {
      var products = await FindProductsBySearchText(searchText);

      List<string> result = new();

      foreach (var product in products) 
      { 
        if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
          result.Add(product.Title);

        if(product.Description != null)
        {
          var punctuaution = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
          var words = product.Description.Split().Select(s => s.Trim(punctuaution));

          foreach(var word in words)
          {
            if(word.Contains(searchText,StringComparison.OrdinalIgnoreCase)&& !result.Contains(word))
              result.Add(word);
          }
        }
      }

      return new ServiceResponse<List<string>>
      {
        Data = result
      };
    }

    public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
    {
      var response = new ServiceResponse<List<Product>>
      {
        Data = await FindProductsBySearchText(searchText)
      };

      return response;
    }

    private async Task<List<Product>> FindProductsBySearchText(string searchText)
    {
      return await _context.Products
          .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
          ||
          p.Description.ToLower().Contains(searchText.ToLower()))
          .Include(p => p.Variants)
          .ToListAsync();
    }
  }
}
