using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Repository
{
    public class ShoppingCartRepository : GenericRepositoryAsync<Cart>, IShoppingCartRepository
    {
       // private readonly ApplicationDbContext_ dbContext;

        public ShoppingCartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //this._dbContext = dbContext;
        }

        public async Task<Cart> AddToCartAsync(Cart _cart)
        {
            await _dbContext.Carts.AddAsync(_cart); 

            return _cart;
        }



        public async Task<Cart> GetCartByCustomerIdAsync(Guid _id)
        {
            var cartFromDb = await _dbContext.Carts.Include(c => c.CartItems)
                .ThenInclude(e=>e.Product).
                FirstOrDefaultAsync(e=>e.CustomerId==_id && !e.IsCheckedOut);

            return cartFromDb;
           
        }
        public Task<string> ClearCartAsync(Guid _id)
        {
            throw new NotImplementedException();
        }

    }
}
