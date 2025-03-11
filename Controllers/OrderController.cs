using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.ServicesInterface;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Places a new order.
        /// </summary>
        /// <param name="orderDto">Order details</param>
        /// <returns>Success message</returns>
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null || orderDto.Items == null || !orderDto.Items.Any())
            {
                return BadRequest("Invalid order data.");
            }

            await _orderService.PlaceOrderAsync(orderDto);
            return Ok(new { message = "Order placed successfully!" });
        }

        /// <summary>
        /// Gets all orders for a user by email.
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>List of orders</returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetOrdersByUser([FromRoute] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email is required.");
            }

            var orders = await _orderService.GetOrdersByUserAsync(email);
            return Ok(orders);
        }
    }
}
