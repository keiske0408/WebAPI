using MediatR;
using WebAPI.Commands.Dto;
using WebAPI.Commands.Response;
using WebAPI.Services;

namespace WebAPI.Commands.Handler;

public class TestDataCommandHandler : IRequestHandler<TestDataDto, TestDataResponse>
{
    private readonly ITestService _service;
    public TestDataCommandHandler(ITestService service)
    {
        _service = service;
    }
    
    public async Task<TestDataResponse> Handle(TestDataDto request, CancellationToken cancellationToken)
    {
        var execute = await _service.AddNewName(request.Name);
        return new TestDataResponse {Message = execute};
    }
}