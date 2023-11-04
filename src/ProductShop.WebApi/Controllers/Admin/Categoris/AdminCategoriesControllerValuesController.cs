using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Persistence.Dtos.Categories;
using ProductShop.Services.Interfaces.Categories;
using ProductShop.Services.Services.Categories;

namespace ProductShop.WebApi.Controllers.Admin.Categoris;

[Route("api/admin/categories")]
[ApiController]
public class AdminCategoriesController : AdminBaseController
{
    private readonly ICategoriesService _service;

    public AdminCategoriesController(ICategoriesService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
         return Ok(await _service.UpdateAsync(categoryId, dto));
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
