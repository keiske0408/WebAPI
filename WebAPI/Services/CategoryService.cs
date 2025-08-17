using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository<Category> _categoryRepository;
    
    public CategoryService(ICategoryRepository<Category> categoryRepository, ITestService testService)
    {
        _categoryRepository = categoryRepository;
    }

    
    public async Task<string> AddNewName(string name)
    {
        return (await _categoryRepository.AddNewName(name)).ToString();
    }

    public async Task<List<Category>> GetAllDataFromCategoryModel()
    {
        return (await _categoryRepository.GetAllAsync()).ToList();
    }
}