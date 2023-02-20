﻿using BlazorEcommerce.Server.Data;

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
        Data = await _context.Products.ToListAsync()
      };

      return response;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int produtcId)
    {
      var response = new ServiceResponse<Product>();
      var product = await _context.Products.FindAsync(produtcId);
      if(product == null) 
      {
        response.Success = true;
        response.Message = "Sorry, but this product";
      }
      response.Data = product;

      return response;
    }
  }
}