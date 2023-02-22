using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class CatergoryController : ControllerBase
    {
        private readonly ICatergoryService _catergoryService;

        public CatergoryController(ICatergoryService catergoryService)
        {
            _catergoryService = catergoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
        {
            var result = await _catergoryService.GetCategoryAsync();
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<ServiceResponse<Category>>> GetCategoriesAsync(int categoryId)
        {
            var result = await _catergoryService.GetCategoryAsync(categoryId);
            return Ok(result);
        }
    }
}
