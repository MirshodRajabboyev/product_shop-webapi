using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Persistence.Dtos.Brands;
using ProductShop.Services.Interfaces.Brands;

namespace ProductShop.WebApi.Controllers.Admin.Brands;

[Route("api/admin/brands")]
[ApiController]
public class AdminBrandsController : AdminBaseController
{
    private readonly IBrandService _service;
  
    public AdminBrandsController(IBrandService service)
    {
        this._service = service;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] BrandCreateDto dto)
    {
        return Ok(await _service.CreatAsync(dto));
    }

    [HttpPut("{brandId}")]
    public async Task<IActionResult> UpdateAsync(long brandId, [FromForm] BrandUpdateDto dto)
    {
        return Ok(await _service.UpdateAsync(brandId, dto));
    }

    [HttpDelete("{brandId}")]
    public async Task<IActionResult> DeleteAsync(long brandId) => Ok(await _service.DeleteAsync(brandId));
}
