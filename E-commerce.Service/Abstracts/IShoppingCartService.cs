using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<Cart>> GetAllAsAsync();
        Task<Cart> AddToCartAsync(Cart cart);

        Task <Cart> GetCartByCartID (Guid cartID);

        Task<Cart> GetCartByCustomerIdAsync(Guid id);
        Task<string> UpdateCartAsync(Cart cart);

        Task<string> ClearCartAsync(Cart cart);
        Task<string> RemoveCartItemAsync(Cart cart);


    }
}
