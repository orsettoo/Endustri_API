using Endustri_API.DTO;
using Endustri_API.Services.Abstract;
using Endustri_API.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endustri_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategories")]

        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("GetUniqueCategory")]

        public IActionResult GetCategory(int id)
        {
            var result = _categoryService.GetCategoryById(id);
            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO request)
        {
            var result = _categoryService.CreateCategory(request);
                return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCategory (EditCategoryDTO request)
        {
            var result = _categoryService.UpdateCategory(request);
                return Ok(result);
        }
    }
}
