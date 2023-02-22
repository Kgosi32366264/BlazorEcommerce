namespace BlazorEcommerce.Client.Services.ProductService
{
  public class ProductService : IProductService
  {
    public event Action ProductsCahnged;
    private readonly HttpClient _httpClient;
    public List<Product> Products { get; set; } = new();
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetProducts(string? categoryUrl = null)
    {
      var result = categoryUrl == null ?
      await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product") :
      await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryUrl}");

        if (result != null && result.Data != null)
            Products = result.Data;

      ProductsCahnged.Invoke();
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }
  }
}
