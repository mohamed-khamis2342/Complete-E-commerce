using E_commerce.Core.Commends.Order;
using E_commerce.Core.DTOs.Order;
using E_commerce.Data.Entities;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace E_commerce.Core.Handlers.Order
{
    public class CreatOrderHandler : IRequestHandler<CreatOrderCommend, ApiResponse<OrderResponseDTO>>
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IproductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IAddressService _addressService;

        public CreatOrderHandler(IOrderService orderService,
            ICustomerService customerService,
            IAddressService addressService,
            IproductService productService,
            IShoppingCartService shoppingCartService)
        {
            this._orderService = orderService;
            this._customerService = customerService;
            this._productService = productService;
            this._shoppingCartService = shoppingCartService;
            this._addressService = _addressService;
        }
        public async Task<ApiResponse<OrderResponseDTO>> Handle(CreatOrderCommend request, CancellationToken cancellationToken)
        {
            var CustomerExist = await _customerService.GetByIdAsync(request.CustomerId);

            if (CustomerExist == null)
                return new ApiResponse<OrderResponseDTO>(400, "Customer dosent exist");

            var BillingAddress = await _addressService.GetByIdAsync(request.BillingAddressId);

            if(BillingAddress == null && BillingAddress.CustomerId != request.BillingAddressId )
                return new ApiResponse<OrderResponseDTO>(400, "Billing Address is invalid or does not belong to the customer.");



            var shippingAddress = await _addressService.GetByIdAsync(request.ShippingAddressId);
            if (shippingAddress == null || shippingAddress.CustomerId != request.CustomerId)
            {
                return new ApiResponse<OrderResponseDTO>(400, "Shipping Address is invalid or does not belong to the customer.");
            }




            string orderNumber = GenerateOrderNumber();

            decimal totalBaseAmount = 0;
            decimal totalDiscountAmount = 0;
            decimal shippingCost = 10.00m; 
            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();
         
            foreach (var itemDto in request.OrderItems)
            {
              
                var product = await _productService.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                {
                    return new ApiResponse<OrderResponseDTO>(404, $"Product with ID {itemDto.ProductId} does not exist.");
                }
             
                if (product.StockQuantity < itemDto.Quantity)
                {
                    return new ApiResponse<OrderResponseDTO>(400, $"Insufficient stock for product {product.Name}.");
                }
               
                decimal basePrice = itemDto.Quantity * product.Price;
                decimal discount = (product.DiscountPercentage / 100.0m) * basePrice;
                decimal totalPrice = basePrice - discount;


          
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    UnitPrice = product.Price,
                    Discount = discount,
                    TotalPrice = totalPrice
                };
             
                orderItems.Add(orderItem);
              
                totalBaseAmount += basePrice;
                totalDiscountAmount += discount;
               
                product.StockQuantity -= itemDto.Quantity;
               await _productService.UpdateProductAsync(product);
           
            }

        
            totalAmount = totalBaseAmount - totalDiscountAmount + shippingCost;
          
            var order = new Entities.Order
            {
                OrderNumber = orderNumber,
                CustomerId = request.CustomerId,
                OrderDate = DateTime.UtcNow,
                BillingAddressId = request.BillingAddressId,
                ShippingAddressId = request.ShippingAddressId,
                TotalBaseAmount = totalBaseAmount,
                TotalDiscountAmount = totalDiscountAmount,
                ShippingCost = shippingCost,
                TotalAmount = totalAmount,
               StatusId = Guid.Parse("A1111111-1111-1111-1111-111111111111"),
                // OrderStatus = OrderStatus.Pending,
                OrderItems = orderItems
            };
 

            await _orderService.CreatOrderAsync(order);
         
            var cart = await _shoppingCartService.GetCartByCustomerIdAsync(request.CustomerId); 
            if (cart != null)
            {
                cart.IsCheckedOut = true;
                cart.UpdatedAt = DateTime.UtcNow;
            
                await _shoppingCartService.UpdateCartAsync(cart);   
            }
            var orderResponse = MapOrderToDTO(order, CustomerExist, BillingAddress, shippingAddress);
            return new ApiResponse<OrderResponseDTO>(200, orderResponse);


        }
        private OrderResponseDTO MapOrderToDTO(Entities.Order order, Customer customer, Entities.Address billingAddress, Entities.Address shippingAddress)
        {
            // Map order items.
            var orderItemsDto = order.OrderItems.Select(oi => new OrderItemResponseDTO
            {
                Id = oi.Id,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice,
                Discount = oi.Discount,
                TotalPrice = oi.TotalPrice
            }).ToList();
            // Create and return the DTO.
            return new OrderResponseDTO
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                BillingAddressId = order.BillingAddressId,
                ShippingAddressId = order.ShippingAddressId,
                TotalBaseAmount = order.TotalBaseAmount,
                TotalDiscountAmount = order.TotalDiscountAmount,
                ShippingCost = order.ShippingCost,
                TotalAmount = Math.Round(order.TotalAmount, 2),
               // OrderStatus = order.OrderStatus.ToString(),
                OrderItems = orderItemsDto
            };
        }
        private static readonly Random _random = new();

        private string GenerateOrderNumber()
        {
            return $"ORD-{DateTime.UtcNow:yyyyMMdd-HHmmss}-{_random.Next(1000, 9999)}";
        }

    }
}
