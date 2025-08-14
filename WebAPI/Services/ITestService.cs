using WebAPI.Models;

namespace WebAPI.Services;

public interface ITestService
{
    Task<List<TestModel>> GetAllDataFromTestModel();
    Task<string> AddNewName(string name);
}