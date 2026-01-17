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
    public class ClearCartHandler : IRequestHandler<ClearCartCommend, ApiResponse<CartResponseDTO>>

    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICartItemService _cartItemService;

        public ClearCartHandler(IShoppingCartService shoppingCartService, ICartItemService cartItemService)
        {
            this._shoppingCartService = shoppingCartService;
            this._cartItemService = cartItemService;
        }
    
        public async Task<ApiResponse<CartResponseDTO>> Handle(ClearCartCommend request, CancellationToken cancellationToken)
        {
           
            var cartFromDb = await _shoppingCartService.GetCartByCustomerIdAsync(request.CustomerId);
      
            if (cartFromDb == null)
            {
                return new ApiResponse<CartResponseDTO>(404, "Active cart not found.");
            }







          
            if (cartFromDb.CartItems.Any())
            {
               
                await _cartItemService.RemoveRangeOfCartItemAsync((List<CartItem>)(cartFromDb.CartItems));
                cartFromDb.UpdatedAt = DateTime.UtcNow;
                return new ApiResponse<CartResponseDTO>(200, "Cart has been cleared successfully.");
            }
          
          


          
            var cartItemsDto = cartFromDb.CartItems?.Select(ci => new CartItemResponseDTO
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice,
                Discount = ci.Discount,
                TotalPrice = ci.TotalPrice
            }).ToList() ?? new List<CartItemResponseDTO>();
         
            decimal totalBasePrice = 0;
            decimal totalDiscount = 0;
            decimal totalAmount = 0;
        
            foreach (var item in cartItemsDto)
            {
                totalBasePrice += item.UnitPrice * item.Quantity;     
                totalDiscount += item.Discount * item.Quantity;         
                totalAmount += item.TotalPrice;                         
            }
         
          var response =   new CartResponseDTO { 
            
                Id = cartFromDb.Id,
                CustomerId =   cartFromDb.CustomerId,
                IsCheckedOut = cartFromDb.IsCheckedOut,
                CreatedAt = cartFromDb.CreatedAt,
                UpdatedAt = cartFromDb.UpdatedAt,
                CartItems = cartItemsDto,
                TotalBasePrice = totalBasePrice,
                TotalDiscount = totalDiscount,
                TotalAmount = totalAmount
            };

            return new ApiResponse<CartResponseDTO>(200, response);

        }
    }
}

