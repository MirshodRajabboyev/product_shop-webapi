using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Utilities;
using ProductShop.Services.Interfaces.Categories;
using ProductShop.Services.Services.Categories;

namespace ProductShop.WebApi.Controllers.Common.Categories;

[Route("api/common/categories")]
[ApiController]
public class CommonCategoriesController : CommonBaseController
{
    private readonly ICategoriesService _service;
    private readonly int maxPageSize = 30;

    public CommonCategoriesController(ICategoriesService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(await _service.GetByIdAsync(categoryId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());
}