using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get() => "Hello World!";
    }
}
