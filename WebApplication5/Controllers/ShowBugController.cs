using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace WebApplication5;

public class MyDynamicControllerRoute : DynamicRouteValueTransformer
{
    public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
    {
        return ValueTask.FromResult(values);
    }
}

[ApiController]
[Route("api/")]
public class ShowBugController : Controller
{
    [HttpPost("test")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)] // This is important because it leads to a lower (better) score when the request enter the ApiVersionMatcherPolicy, even when requested with http GET
    public IActionResult MyPost()
    {
        return Ok("OK POST");
    }

    [HttpGet("test")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult MyGet()
    {

        return Ok("OK GET");
    }
}