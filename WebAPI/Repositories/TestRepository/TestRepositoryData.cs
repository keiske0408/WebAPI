using Microsoft.EntityFrameworkCore;
using WebAPI.db;
using WebAPI.Models;

namespace WebAPI.Repositories.TestRepository;

public class TestRepositoryData : IRepository<TestModel>
{
    private readonly ApplicationDatabase _context;
    public TestRepositoryData(ApplicationDatabase context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TestModel>> GetAllAsync()
    {
        return await _context.TestModels.ToListAsync();
    }

    public async Task<string> AddNewName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "Name is empty";
        }

        var testModel = new TestModel()
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        await _context.TestModels.AddAsync(testModel);
        await _context.SaveChangesAsync();
        return "Success";
    }
}