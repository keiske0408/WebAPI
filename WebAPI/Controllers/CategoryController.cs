using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Commands.Dto;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly IMediator _mediator;
    
    public CategoryController(ICategoryService service)
    {
        _service = service;
        _mediator = _mediator;
    }

    [HttpGet]
    [Route("get-all-test-data")]
    public async Task<IActionResult> GetAllData()
    {
        var data = await _service.GetAllDataFromCategoryModel();
        return Ok(data);
    }

    [HttpPost]
    [Route("add-new-name")]
    public async Task<IActionResult> CreateNewName([FromBody] TestDataDto dto)
    {
        var result = await _mediator.Send(new TestDataDto {Name = dto.Name});
        return Ok(result);
    }
}