using Asp.Versioning;
using FindIt.Application.Interfaces;
using FindIt.Server.Extensions;
using FindIt.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FindIt.Server.Controllers.V1
{
    public class CategoryController(ICategoryService categoryService) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var result = await categoryService.GetAllCategoriesAsync();
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var result = await categoryService.GetCategoryByIdAsync(id);
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryRequest categoryRequest)
        {
            var result = await categoryService.CreateCategoryAsync(categoryRequest);
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryRequest categoryRequest)
        {
            var result = await categoryService.UpdateCategoryAsync(id, categoryRequest);
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }
        

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchCategories([FromQuery] string query)
        {
            var result = await categoryService.SearchAsync(query);
            return result.IsSuccess ? result.ToSuccess(result.Value) : result.ToProblem();
        }
    }
}
