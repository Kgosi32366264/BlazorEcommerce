﻿namespace BlazorEcommerce.Server.Services.ProductService
{
  public interface IProductService
  {
    Task<ServiceResponse<List<Product>>> GetProductAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int produtcId);
    Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
  }
}
