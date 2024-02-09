using AutoMapper;
using Endustri_API.DatabaseContext;
using Endustri_API.DTO;
using Endustri_API.Entity;
using Endustri_API.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Endustri_API.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category)
        {
            var map = _mapper.Map<CreateCategoryDTO, Category>(category);
            map.CreatedDate = DateTime.Now;
            map.UpdatedDate = DateTime.Now;
            var addedObj = _context.Categories.Add(map);
            var response = _mapper.Map<Category, CreateCategoryDTO>(addedObj.Entity);
           await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = _context.Categories.Find(id);
            if(result != null)
            {
                _context.Categories.Remove(result);
                 _context.SaveChanges();
                return true;
            }
           return false;

        }

        public async Task<ServiceResponse<List<Category>>> GetAllCategories()
        {
            var result =  _context.Categories.Include(x => x.Products).ToList();
            ServiceResponse<List<Category>> _category = new ServiceResponse<List<Category>>();
            if(result != null)
            {
                _category.Data = result;
                _category.Success = true;
                _category.Message = "Categories Listed";
                return _category;
            }
            return _category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.Id == id);
            return result ;
        }

        public Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category)
        {
            var result = _context.Categories.Find(category.Id);
            if(result != null)
            {
                var map = _mapper.Map<EditCategoryDTO, Category>(category);
                result.CategoryName = map.CategoryName;
                result.CategoryDescription = map.CategoryDescription;
                result.UpdatedDate = DateTime.Now;
                result.CreatedDate = DateTime.UtcNow;
              var response =  _mapper.Map<Category, EditCategoryDTO>(map);
                 _context.SaveChanges();
                return response;
            }
            return null;
        }
    }
}
