﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
      var result = await _productService.GetProductAsync();
      return Ok(result);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProducts(int productId)
    {
      var result = await _productService.GetProductAsync(productId);
      return Ok(result);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProductByCategory(string categoryUrl)
    {
      var result = await _productService.GetProductByCategory(categoryUrl);
      return Ok(result);
    }
  }
}
