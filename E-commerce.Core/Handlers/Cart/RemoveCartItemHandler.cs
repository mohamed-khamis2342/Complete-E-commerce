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
    public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommend, ApiResponse<CartResponseDTO>>
    {

        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICartItemService _cartItemService;

        public RemoveCartItemHandler(IShoppingCartService shoppingCartService, ICartItemService cartItemService)
        {
            this._shoppingCartService = shoppingCartService;
            this._cartItemService = cartItemService;
        }
        public async Task<ApiResponse<CartResponseDTO>> Handle(RemoveCartItemCommend request, CancellationToken cancellationToken)
        {
            var CartFromDb = await _shoppingCartService.GetCartByCustomerIdAsync(request.CustomerId);

            if (CartFromDb == null)
            {
                return new ApiResponse<CartResponseDTO>(404, "Active cart not found.");
            }
            // Find the cart item to remove.
            var cartItem = CartFromDb.CartItems.FirstOrDefault(ci => ci.Id == request.CartItemId);
            if (cartItem == null)
            {
                return new ApiResponse<CartResponseDTO>(404, "Cart item not found.");
            }

         
            await _cartItemService.RemoveCartItemAsync(cartItem);
            CartFromDb.UpdatedAt = DateTime.UtcNow;

            CartFromDb = await _shoppingCartService
               .GetCartByCartID(    CartFromDb.Id) ?? new Entities.Cart();
            // 6️⃣ Calculate totals
            var totalBasePrice =
                CartFromDb.CartItems.Sum(ci => ci.UnitPrice * ci.Quantity);

            var totalDiscount =
                CartFromDb.CartItems.Sum(ci => ci.Discount * ci.Quantity);

            var totalAmount = totalBasePrice - totalDiscount;

            // 7️⃣ Map to DTO
            var cartDTO = new CartResponseDTO
            {
                Id = CartFromDb.Id,
                CustomerId = CartFromDb.CustomerId,
                CreatedAt = CartFromDb.CreatedAt,
                UpdatedAt = CartFromDb.UpdatedAt,
                IsCheckedOut = CartFromDb.IsCheckedOut,

                TotalBasePrice = totalBasePrice,
                TotalDiscount = totalDiscount,
                TotalAmount = totalAmount,

                CartItems = CartFromDb.CartItems.Select(ci => new CartItemResponseDTO
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
