using AutoMapper;
using Endustri_API.DatabaseContext;
using Endustri_API.DTO;
using Endustri_API.DTO.ProductDTO;
using Endustri_API.Entity;
using Endustri_API.Services.Abstract;

namespace Endustri_API.Services.Concrete
{
    public class ProductService : IProductService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductDTO> CreateProduct(CreateProductDTO Product)
        {
            var map = _mapper.Map<CreateProductDTO, Product>(Product);
            map.CreatedDate = DateTime.Now;
            map.UpdatedDate = DateTime.Now;
            var addedObj = _context.Products.Add(map);
            var response = _mapper.Map<Product, CreateProductDTO>(addedObj.Entity);
            await _context.SaveChangesAsync();
            return response;
        }

        public Task<CreateProductDTO> CreateProduct(Product Product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = _context.Products.Find(id);
            if (result != null)
            {
                _context.Products.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var result = _context.Products.ToList();
            ServiceResponse<List<Product>> _Product = new ServiceResponse<List<Product>>();
            if (result != null)
            {
                _Product.Data = result;
                _Product.Success = true;
                _Product.Message = "Products Listed";
                return _Product;
            }
            return _Product;
        }

        public async Task<Product> GetProductById(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Task<Product> UpdateProduct(Product Product)
        {
            throw new NotImplementedException();
        }

        public async Task<EditProductDTO> UpdateProduct(EditProductDTO Product)
        {
            var result = _context.Products.Find(Product.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditProductDTO, Product>(Product);
                result.ProductName = map.ProductName;
                result.ProductDescription = map.ProductDescription;
                result.ProductPrice = map.ProductPrice;
                result.CategoryId = map.CategoryId;
                result.UpdatedDate = DateTime.Now;
                result.CreatedDate = DateTime.UtcNow;
                var response = _mapper.Map<Product, EditProductDTO>(map);
                _context.SaveChanges();
                return response;
            }
            return null;
        }
    }
}

