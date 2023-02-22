﻿namespace BlazorEcommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetCategories();
        Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId);
    }
}
