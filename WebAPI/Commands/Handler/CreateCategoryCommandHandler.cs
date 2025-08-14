using MediatR;
using WebAPI.Commands.Response;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI.Commands.Handler;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryService _service;
    public CreateCategoryCommandHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var execute = await _service.AddNewName(request.Name);
        return new Category {Description = execute};
    }
}
