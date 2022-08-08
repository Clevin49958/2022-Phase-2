using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.Backend.Services;
using MSA.Phase2.Backend.Models;

namespace MSA.Phase2.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _client;
        /// <summary />
        public WeatherController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("weather");
        }
        /// <summary>
        /// Gets the raw JSON for the hot feed in reddit
        /// </summary>
        /// <returns>A JSON object representing the hot feed in reddit</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllWeather()
        {
            List<Location> locations = LocationService.GetAll();
            // List<Task<HttpResponseMessage>> results = new List<Task<HttpResponseMessage>>();

            var results = await Task.WhenAll(locations.Select(location =>
            _client.GetAsync($"/data/3.0/onecall?lat={location.Lat}&lon={location.Lng}&appid=xxx")));
            var contents = await Task.WhenAll(results.Select(res => res.Content.ReadAsStringAsync()));
            return Ok(contents);
        }
    }
}