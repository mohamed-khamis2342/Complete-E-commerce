using E_commerce.Core.Commends.Cart;
using E_commerce.Core.DTOs.Cart;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Cart
{
    public class AddToCartHandler
     : IRequestHandler<AddToCartCommend, ApiResponse<CartResponseDTO>>
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IproductService _productService;
        private readonly ICartItemService _cartItemService;

        public AddToCartHandler(
            IShoppingCartService shoppingCartService,
            IproductService productService,
            ICartItemService cartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _cartItemService = cartItemService;
        }

        public async Task<ApiResponse<CartResponseDTO>> Handle(
            AddToCartCommend request,
            CancellationToken cancellationToken)
        {
          
            var product = await _productService.GetByIdAsync(request.ProductId);

            if (product == null)
                return new ApiResponse<CartResponseDTO>(
                    400, "Product is not available");

            if (product.StockQuantity < request.Quantity)
                return new ApiResponse<CartResponseDTO>(
                    400,
                    $"Only {product.StockQuantity} units of {product.Name} are available.");

           
            var cart = await _shoppingCartService
                .GetCartByCustomerIdAsync(request.CustomerId);

            if (cart == null)
            {
                cart = new Entities.Cart
                {
                    CustomerId = request.CustomerId,
                    IsCheckedOut = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CartItems = new List<CartItem>()
                };

                await _shoppingCartService.AddToCartAsync(cart);
            }

         
            var existingCartItem = cart.CartItems
                .FirstOrDefault(ci => ci.ProductId == request.ProductId);

            if (existingCartItem != null)
            {
             
                if (existingCartItem.Quantity + request.Quantity > product.StockQuantity)
                    return new ApiResponse<CartResponseDTO>(
                        400,
                        "Adding this quantity exceeds available stock.");

                existingCartItem.Quantity += request.Quantity;
                existingCartItem.TotalPrice =
                    (existingCartItem.UnitPrice - existingCartItem.Discount)
                    * existingCartItem.Quantity;
                existingCartItem.UpdatedAt = DateTime.UtcNow;

                await _cartItemService.UpdateCartItemAsync(existingCartItem);
            }
            else
            {
                
                var discountPerUnit = product.DiscountPercentage > 0
                    ? product.Price * product.DiscountPercentage / 100
                    : 0;

                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = request.Quantity,
                    UnitPrice = product.Price,
                    Discount = discountPerUnit,
                    TotalPrice = (product.Price - discountPerUnit) * request.Quantity,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _cartItemService.AddToCarItemtAsync(cartItem);
            }

            cart.UpdatedAt = DateTime.UtcNow;
         
            await _shoppingCartService.UpdateCartAsync(cart);

            cart = await _shoppingCartService
                .GetCartByCartID(cart.Id) ?? new Entities.Cart();

    
            var totalBasePrice =
                cart.CartItems.Sum(ci => ci.UnitPrice * ci.Quantity);

            var totalDiscount =
                cart.CartItems.Sum(ci => ci.Discount * ci.Quantity);

            var totalAmount = totalBasePrice - totalDiscount;

            var cartDTO = new CartResponseDTO
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CreatedAt = cart.CreatedAt,
                UpdatedAt = cart.UpdatedAt,
                IsCheckedOut = cart.IsCheckedOut,

                TotalBasePrice = totalBasePrice,
                TotalDiscount = totalDiscount,
                TotalAmount = totalAmount,

                CartItems = cart.CartItems.Select(ci => new CartItemResponseDTO
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.UnitPrice,
                    Discount = ci.Discount,
                    TotalPrice = ci.TotalPrice
                }).ToList()
            };

            return new ApiResponse<CartResponseDTO>(200, cartDTO);
        }
    }

}

