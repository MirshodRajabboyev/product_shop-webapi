using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProductShop.WebApi.Controllers.Admin;

[ApiController]
//[Authorize(Roles = "Admin, Head")]
[AllowAnonymous]
public abstract class AdminBaseController : ControllerBase
{
}
