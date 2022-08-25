using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Services;
using Restaurant.API.Data.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IReservationService _reservationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationService"></param>
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(201, type: typeof(Reservation), description: "Created a reservation")]
        [SwaggerResponse(400, type: typeof(Reservation), description: "Created a reservation was unsuccessful")]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {

            if (reservation is null) return BadRequest();

            var results = await _reservationService.CreateReservation(reservation);

            if (results) { 
                return Created(nameof(CreateReservation), true);
            }
            else
            {
                return BadRequest("reservation already exists.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var newReseravtion = new Reservation();
            if (newReseravtion is null) return BadRequest();

            var result = await _reservationService.GetReservations();

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateReservation"></param>
        /// <returns></returns>
        [HttpPut("Update-Reservation")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(200, type: typeof(Reservation), description: "Updated a reservation")]
        [SwaggerResponse(400, type: typeof(Reservation), description: "Updated a reservation was unsuccessful")]
        public async Task<IActionResult> UpdateReservation([FromBody] Reservation updateReservation , int id)
        {

            if (id != updateReservation.Id) return BadRequest();

            var existingReservation = await _reservationService.UpdateReservation(updateReservation,id);

            if (existingReservation is null) return NotFound("Not found");

            return Ok(existingReservation);
        }

    }
}
