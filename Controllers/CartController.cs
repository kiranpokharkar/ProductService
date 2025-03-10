using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Application.Services;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // ✅ Add/Update Cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartDto cartDto)
        {
            if (cartDto == null || string.IsNullOrEmpty(cartDto.Email))
            {
                return BadRequest("Invalid cart data.");
            }

            await _cartService.AddToCartAsync(cartDto);
            return Ok("Cart updated successfully.");
        }

        // ✅ Get Cart by Email
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
