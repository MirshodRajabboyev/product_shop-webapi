using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Utilities;
using ProductShop.Persistence.Dtos.Products;
using ProductShop.Services.Interfaces.Products;

namespace ProductShop.WebApi.Controllers.Admin.Products;

[Route("api/admin/products")]
[ApiController]
public class AdminProductsController : AdminBaseController
{
    private readonly IProductService _service;
    private readonly int maxPageSize = 30;

    public AdminProductsController(IProductService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateAsync(long productId, [FromForm] ProductUpdateDto dto)
    {
        return Ok(await _service.UpdateAsync(productId, dto));
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId)
        => Ok(await _service.DeleteAsync(productId));
}
