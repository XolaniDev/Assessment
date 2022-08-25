using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.API.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using Restaurant.API.Data.Models;

namespace Restaurant.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(201, type: typeof(Order), description: "Created a order")]
        [SwaggerResponse(400, type: typeof(Order), description: "Created a order was unsuccessful")]
        public async Task<IActionResult> PlaceOrder([FromBody] Order orders)
        {
            if (orders is null) return BadRequest("Not created");

            var results = await _orderService.PlaceOrder(orders);

                if (results)
                {
                    return Created(nameof(PlaceOrder), true);
                }
                else
                {
                    return BadRequest("reservation already exists.");
                }
            
        }
    }
}
