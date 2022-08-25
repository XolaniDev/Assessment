using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Restaurant.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestuarentController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRestaurantService _restaurantService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantService"></param>
        public RestuarentController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        [HttpGet("Get-all-restaurants")]
        [Produces("application/json")]
        [SwaggerResponse(200, description: "restaurants retrieved")]
        [SwaggerResponse(404, description: "Restaraunt not found in database")]
        [SwaggerResponse(400, description: "Invalid restaurant name entered")]
        public async Task<IActionResult> GetRestaurantByName(string name)
        {
            if (name is null) return BadRequest("Do not match");

            var results = await _restaurantService.GetRestaurantByName(name);

            return Ok(results);
        }
    }
}
