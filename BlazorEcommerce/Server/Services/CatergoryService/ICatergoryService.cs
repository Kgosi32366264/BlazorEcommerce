namespace BlazorEcommerce.Server.Services.CatrgoryService
{
    public interface ICatergoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoryAsync();
        Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId);
    }
}
