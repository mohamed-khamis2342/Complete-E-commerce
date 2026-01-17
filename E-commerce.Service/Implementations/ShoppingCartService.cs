using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            this._shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<Cart> AddToCartAsync(Cart cart)
        {
          var  _cart =  await _shoppingCartRepository.AddAsync(cart);   

            return _cart;
        }

        public Task<string> ClearCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartByCartID(Guid cartID)
        {
           var Cart = await _shoppingCartRepository.GetByIdAsync(cartID);   

            return Cart;
        }

        public Task<IEnumerable<Cart>> GetAllAsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartByCustomerIdAsync(Guid id)
        {
            var CartFromdb = await _shoppingCartRepository.GetCartByCustomerIdAsync(id);

          return CartFromdb;

        }

        public Task<string> RemoveCartItemAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateCartAsync(Cart cart)
        {
            var result =  _shoppingCartRepository.UpdateAsync(cart);


            if (!result.IsCompleted)
            {
                return "Something went wrong";
            }

            return string.Empty;

        }
    }
}
