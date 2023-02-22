﻿namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsCahnged;
        List<Product> Products { get; set; }
        Task GetProducts(string? url = null);
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
    }
}
