using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.Backend.Models;
using MSA.Phase2.Backend.Services;

namespace MSA.Phase2.Backend.Controllers
{
    /// <summary>
    /// Records a list of subscribed locations with their coordinates
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        public LocationController()
        {
        }


        /// <summary>
        /// Get all subscribed locations
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Location>> GetAll()
        {
            return LocationService.GetAll();
        }

        /// <summary>
        /// Add the coordinate of a location
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create(Location location)
        {
            if (LocationService.Add(location))
            {
                return CreatedAtAction(nameof(Create), location);
            }
            else
            {
                return BadRequest("Location already exist");
            }

        }

        /// <summary>
        /// Update the coordinate of a location
        /// </summary>
        [HttpPut("{name}")]
        public IActionResult Update(string name, Location location)
        {
            if (name != location.Name)
                return BadRequest("Inconsistent name");
            if (LocationService.Get(name) is null)
            {
                return NotFound();
            }

            LocationService.Update(location);
            return NoContent();
        }

        /// <summary>
        /// Unsubscribe from a coordinate
        /// </summary>
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if (LocationService.Get(name) is null)
            {
                return NotFound();
            }
            else
            {
                LocationService.Delete(name);
                return NoContent();
            }
        }
    }
}