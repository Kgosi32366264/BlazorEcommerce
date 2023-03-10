namespace BlazorEcommerce.Server.Services.ProductService
{
  public interface IProductService
  {
    Task<ServiceResponse<List<Product>>> GetProductAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int produtcId);
    Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
    Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
    Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
  }
}
