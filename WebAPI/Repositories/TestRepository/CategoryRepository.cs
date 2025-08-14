using Microsoft.EntityFrameworkCore;
using WebAPI.db;
using WebAPI.Models;

namespace WebAPI.Repositories.TestRepository;

public class CategoryRepository : ICategoryRepository<Category>
{
    private readonly ApplicationDatabase _context;

    public CategoryRepository(ApplicationDatabase context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<string> AddNewName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "Name is empty";
        }

        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return "Success";
    }
}
    


