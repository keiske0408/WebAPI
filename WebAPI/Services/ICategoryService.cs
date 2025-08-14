using WebAPI.Models;

namespace WebAPI.Services;

public interface ICategoryService
{
    Task<string> AddNewName(string name);
    Task<List<Category>> GetAllDataFromCategoryModel();
}