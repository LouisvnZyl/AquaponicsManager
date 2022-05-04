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
            _logger.LogInformation("Requesting the retrieval of the health api");

            var x = new List<string>()
            {
                { "Test" },
                { "Test 2" }
            };

            for (int i = 0; i < 5; i++)
            {
                x.Add(i.ToString());
            }

            return Ok(x);
        }

        [HttpPost("{id}")]
        public IActionResult TestPostEndpoint(int id)
        {
            _logger.LogInformation("Posting a value to the api ${id}", id);


            return Ok("Post Was recieved");
        }

    }
}
