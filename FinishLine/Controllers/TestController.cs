using Microsoft.AspNetCore.Mvc;

namespace FinishLine.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Je suis un controller qui marche");
        }
    }
}
