using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Application.Services;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        /// <summary>
        /// Adds an item to the cart.
        /// </summary>
        /// <param name="cartDto">The cart data transfer object containing the email and product details.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartDto cartDto)
        {
            if (cartDto == null || string.IsNullOrEmpty(cartDto.Email))
            {
                return BadRequest("Invalid cart data.");
            }

            await _cartService.AddToCartAsync(cartDto);
            return Created();
        }

        /// <summary>
        /// Retrieves the cart for a specific user by email.
        /// </summary>
        /// <param name="email">The email of the user whose cart is to be retrieved.</param>
        /// <returns>The user's cart or an error response if not found.</returns>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetCart(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            var cart = await _cartService.GetCartAsync(email);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            return Ok(cart);
        }
    }
}
