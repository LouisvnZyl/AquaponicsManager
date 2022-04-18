using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace AquaponicsManager.WebHost.Controllers
{
    [ApiController]
    [Route("api/health")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HealthCheckController : Controller
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult TestEndpoint()
        {
            var x = new List<string>()
            {
                { "Test" },
                { "Test 2" }
            };

            return Ok(x);
        }

    }
}