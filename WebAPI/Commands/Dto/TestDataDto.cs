using MediatR;
using WebAPI.Commands.Response;

namespace WebAPI.Commands.Dto;

public class TestDataDto : IRequest<TestDataResponse> 
{
    public string Name { get; set; }
}