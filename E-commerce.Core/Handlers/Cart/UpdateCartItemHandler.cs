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
    public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommend, ApiResponse<CartResponseDTO>>
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICartItemService _cartItemService;

        public UpdateCartItemHandler(IShoppingCartService shoppingCartService,ICartItemService cartItemService)
        {
            this._shoppingCartService = shoppingCartService;
            this._cartItemService = cartItemService;
        }
        public async Task<ApiResponse<CartResponseDTO>> Handle(UpdateCartItemCommend request, CancellationToken cancellationToken)
        {
            var CartFromDb = await _shoppingCartService.GetCartByCustomerIdAsync(request.CustomerId);


            if (CartFromDb == null) {
                return new ApiResponse<CartResponseDTO>(404, "Cart item not found.");
            }

            var CartItem = CartFromDb.CartItems.FirstOrDefault(e => e.Id == request.CartItemId);
            if (CartItem == null)
            {
                return new ApiResponse<CartResponseDTO>(404, "Cart item not found.");
            }



            // Update the cart item's quantity and recalculate its total price.
            CartItem.Quantity = request.Quantity;
            CartItem.TotalPrice = (CartItem.UnitPrice - CartItem.Discount) * CartItem.Quantity;
            CartItem.UpdatedAt = DateTime.UtcNow;
            // Mark the cart item as updated.
    
            await _cartItemService.UpdateCartItemAsync(CartItem);


            // Update the cart's updated timestamp.
            CartFromDb.UpdatedAt = DateTime.UtcNow;
            

            await _shoppingCartService.UpdateCartAsync(CartFromDb);

            CartFromDb = await _shoppingCartService
               .GetCartByCartID(CartFromDb.Id) ?? new Entities.Cart();

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
