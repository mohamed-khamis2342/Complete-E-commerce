using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class CartitemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartitemService(ICartItemRepository cartItemRepository)
        {
            this._cartItemRepository = cartItemRepository;
        }
        public async Task<CartItem> AddToCarItemtAsync(CartItem cartItem)
        {
              var CartItem =  await _cartItemRepository.AddAsync(cartItem); 

            return CartItem;
        }

        public Task<string> ClearCartAsync(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetAllAsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetCartByCustomerIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RemoveCartItemAsync(CartItem cartItem)
        {
            var UpdatedCartItem =  _cartItemRepository.DeleteAsync(cartItem);

            if (!UpdatedCartItem.IsCompleted)
            {
                return "Something went wrong";
            }

            return string.Empty;
        }

        public async Task<string> UpdateCartItemAsync(CartItem cartItem)
        {
            var UpdatedCartItem =  _cartItemRepository.UpdateAsync(cartItem);

            if (!UpdatedCartItem.IsCompleted) {
                return "Something went wrong";
            }

            return string.Empty;
        }
      public async  Task<string> RemoveRangeOfCartItemAsync(List<CartItem> cartItems)
        {
        var reng  =   _cartItemRepository.DeleteRangeAsync(cartItems);
            if (!reng.IsCompleted)
            {
                return "Something went wrong";
            }

            return string.Empty;
        }
    }
}
