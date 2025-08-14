using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class TestService : ITestService
{
    private readonly IRepository<TestModel> _repository;

    public TestService(IRepository<TestModel> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<TestModel>> GetAllDataFromTestModel()
    {
        return (await _repository.GetAllAsync()).ToList();
    }

    public async Task<string> AddNewName(string name)
    {
        return await _repository.AddNewName(name);
    }
}