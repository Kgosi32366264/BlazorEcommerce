using BlazorEcommerce.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly DataContext _context;
    public ProductController(DataContext context)
    {
      _context = context;  
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProduct()
    {
      var prodcuts = await _context.Products.ToListAsync();
      return Ok(prodcuts);
    }
  }
}
