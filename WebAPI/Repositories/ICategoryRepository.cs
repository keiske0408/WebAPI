using WebAPI.Models;

namespace WebAPI.Repositories;

public interface ICategoryRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<string> AddNewName(string name);
}