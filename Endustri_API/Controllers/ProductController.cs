using Endustri_API.DTO;
using Endustri_API.DTO.ProductDTO;
using Endustri_API.Services.Abstract;
using Endustri_API.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endustri_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet("GetAllProducts")]

        public IActionResult GetProducts()
        {
            var result = _ProductService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("GetUniqueProduct")]

        public IActionResult GetProduct(int id)
        {
            var result = _ProductService.GetProductById(id);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _ProductService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDTO request)
        {
            var result = _ProductService.CreateProduct(request);
                return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateProduct (EditProductDTO request)
        {
            var result = _ProductService.UpdateProduct(request);
                return Ok(result);
        }
    }
}
