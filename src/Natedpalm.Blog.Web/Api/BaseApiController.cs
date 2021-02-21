using Microsoft.AspNetCore.Mvc;

namespace Natedpalm.Blog.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
