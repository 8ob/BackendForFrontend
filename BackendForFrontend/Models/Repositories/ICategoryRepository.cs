using BackendForFrontend.Models.EFModels;

namespace BackendForFrontend.Models.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category1>> GetAllCategoriesAsync();
        Task<Category1> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(Category1 category);
        Task UpdateCategoryAsync(Category1 category);
        Task DeleteCategoryAsync(Category1 category);
    }
}
