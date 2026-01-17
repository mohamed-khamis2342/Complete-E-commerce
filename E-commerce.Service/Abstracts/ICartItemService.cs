using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetAllAsAsync();
        Task<CartItem> AddToCarItemtAsync(CartItem cartItem);

        Task<CartItem> GetCartByCustomerIdAsync(Guid id);
        Task<string> UpdateCartItemAsync(CartItem cartItem);

        Task<string> ClearCartAsync(CartItem cartItem);
        Task<string> RemoveCartItemAsync(CartItem cartItem);
        Task<string> RemoveRangeOfCartItemAsync (List <CartItem> cartItems);
    }
}
