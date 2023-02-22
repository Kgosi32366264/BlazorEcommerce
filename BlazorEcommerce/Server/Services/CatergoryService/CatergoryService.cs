namespace BlazorEcommerce.Server.Services.CatrgoryService
{
  public class CatergoryService: ICatergoryService
  {
    private readonly DataContext _context;
    public CatergoryService(DataContext context)
    {
       _context = context; 
    }

    public async Task<ServiceResponse<List<Category>>> GetCategoryAsync()
    {
      var response = new ServiceResponse<List<Category>>
      {
          Data = await _context.Categories.ToListAsync()
      };
      return response;
    }

    public async Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId)
    {
      var response = new ServiceResponse<Category>();
      var product = await _context.Categories.FindAsync(categoryId);
      if (product == null)
      {
          response.Success = true;
          response.Message = "Sorry, but this category";
      }
      response.Data = product;

      return response;
    }
  }
}
