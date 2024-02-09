using AutoMapper;
using Endustri_API.DTO;
using Endustri_API.DTO.ProductDTO;
using Endustri_API.Entity;

namespace Endustri_API.MappingProfile
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category,EditCategoryDTO>().ReverseMap();
            CreateMap<Product,EditProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }
    }
}
