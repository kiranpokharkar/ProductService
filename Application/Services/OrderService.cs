using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;

namespace ProductService.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IProductService productService,
            ICartService cartService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _cartService = cartService;
            _mapper = mapper;
        }

        public async Task PlaceOrderAsync(OrderDto orderDto)
        {
            var productIds = orderDto.Items.Select(i => i.ProductId).ToList();
            var products = await _productService.GetProductsByIdsAsync(productIds);

            if (products.Count != productIds.Count)
            {
                throw new Exception("One or more products are invalid.");
            }

            // Check stock availability
            foreach (var item in orderDto.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    throw new Exception($"Product {item.ProductId} is out of stock.");
                }
            }

            // Deduct stock
            foreach (var item in orderDto.Items)
            {
                await _productService.UpdateStockAsync(item.ProductId, -item.Quantity);
            }

            // Calculate total order amount
            decimal totalOrderAmount = orderDto.Items.Sum(i =>
                products.First(p => p.Id == i.ProductId).Price * i.Quantity
            );

            // Map order
            var order = new Order
            {
                Email = orderDto.Email,
                Items = orderDto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = products.First(p => p.Id == i.ProductId).Price
                }).ToList(),
                TotalOrderAmount = totalOrderAmount, // ✅ Save the total amount
                CreatedAt = DateTime.UtcNow
            };

            // Save order
            await _orderRepository.SaveOrderAsync(order);

            // Clear cart
            await _cartService.ClearCartAsync(orderDto.Email);
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string email)
        {
            return await _orderRepository.GetOrdersByEmailAsync(email);
        }
    }
}
