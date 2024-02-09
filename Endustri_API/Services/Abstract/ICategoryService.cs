using Endustri_API.DTO;
using Endustri_API.Entity;

namespace Endustri_API.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CreateCategoryDTO> CreateCategory(CreateCategoryDTO category);
        Task<EditCategoryDTO> UpdateCategory(EditCategoryDTO category);
        Task <bool> DeleteCategory(int id);
        Task<ServiceResponse<List<Category>>> GetAllCategories();

        Task<Category> GetCategoryById(int id);
    }
}
