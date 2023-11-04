using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductShop.WebApi.Controllers.Common;

[ApiController]
[AllowAnonymous]
public abstract class CommonBaseController : ControllerBase
{
}