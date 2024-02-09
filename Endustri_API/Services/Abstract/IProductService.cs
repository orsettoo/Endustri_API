using Endustri_API.DTO;
using Endustri_API.DTO.ProductDTO;
using Endustri_API.Entity;

namespace Endustri_API.Services.Abstract
{
    public interface IProductService
    {
        Task<CreateProductDTO> CreateProduct(CreateProductDTO Product);
        Task<EditProductDTO> UpdateProduct(EditProductDTO Product);
        Task<bool> DeleteProduct(int id);
        Task<ServiceResponse<List<Product>>> GetAllProducts();

        Task<Product> GetProductById(int id);
    }
}
