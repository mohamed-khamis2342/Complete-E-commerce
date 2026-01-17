using E_commerce.Core.DTOs.Cart;
using E_commerce.Core.Queries.ShoppingCart;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Cart
{
    public class GetCartByCustomerIdHandler : IRequestHandler<GetCartByCustomerIdQuery, ApiResponse<CartResponseDTO>>
    {
        private readonly IShoppingCartService _shoppingCartService;

        public GetCartByCustomerIdHandler(IShoppingCartService shoppingCartService)
        {
            this._shoppingCartService = shoppingCartService;
        }

        public async Task<ApiResponse<CartResponseDTO>> Handle(GetCartByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var CartFromDb = await _shoppingCartService.GetCartByCustomerIdAsync(request.CustomerId);

            if (CartFromDb == null)
            {

                var emptyCartDTO = new CartResponseDTO
                {
                    CustomerId = request.CustomerId,
                    IsCheckedOut = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CartItems = new List<CartItemResponseDTO>(),
                    TotalBasePrice = 0,
                    TotalDiscount = 0,
                    TotalAmount = 0
                };

                return new ApiResponse<CartResponseDTO>(200, emptyCartDTO);
            }
            // 6️⃣ Calculate totals
            var totalBasePrice =
                CartFromDb.CartItems.Sum(ci => ci.UnitPrice * ci.Quantity);

            var totalDiscount =
                CartFromDb.CartItems.Sum(ci => ci.Discount * ci.Quantity);

            var totalAmount = totalBasePrice - totalDiscount;

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
