using AquaponicsManager.WebHost.Models.HealthCheck;
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
        public IActionResult GetHealthCheck()
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
        public IActionResult PostHealthCheck(int id)
        {
            _logger.LogInformation("Posting a value to the api ${id}", id);


            return Ok("Post was recieved");
        }

        [HttpPut("{id}")]
        public IActionResult PutHealthCheck(int id)
        {
            _logger.LogInformation("Putting a value to the api ${id}", id);


            return Ok("Put was recieved");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHealthCheck(int id)
        {
            _logger.LogInformation("Deleting a value to the api ${id}", id);


            return Ok("Delete was recieved");
        }

        [HttpPost("Body")]
        public IActionResult PostBody([FromForm] KeyValueDto data)
        {
            _logger.LogInformation("Posting a value to the api {data}", data.Key);

            var dogs = new List<Dog>
            {
                new Dog
                {
                    Name = "Kenny",
                    Breed = "Chihuahua",
                    Colour = "Caremel/White",
                    Gender = "Male"
                },
                new Dog
                {
                    Name = "Dolly",
                    Breed = "Chihuahua",
                    Colour = "Black/White",
                    Gender = "Femail"
                },new Dog
                {
                    Name = "Zoey",
                    Breed = "Jack-Russel",
                    Colour = "Brow/White",
                    Gender = "Female"
                }
            };

            _logger.LogInformation("Dog Name {name}", dogs[2].GetName());

            foreach (var dog in dogs)
            {
                _logger.LogInformation("Dog Summary: ", dog.DogSummary());
            }

            return Ok(dogs);
        }
    }
}
