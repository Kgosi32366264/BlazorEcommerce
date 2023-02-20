﻿namespace BlazorEcommerce.Client.Services
{
  public class ProductService : IProductService
  {
    private readonly HttpClient _httpClient; 
    public List<Product> Products { get; set; } = new();
    public ProductService(HttpClient httpClient)
    {
      _httpClient = httpClient; 
    }

    public async Task GetProducts()
    {
      var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
      if (result != null && result.Data != null)
        Products = result.Data;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
      var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
      return result;
    }
  }
}
