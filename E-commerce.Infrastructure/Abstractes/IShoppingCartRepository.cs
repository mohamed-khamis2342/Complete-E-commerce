using E_commerce.Entities;
using E_commerce.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Abstractes
{
    public interface IShoppingCartRepository:IGenericRepositoryAsync<Cart>
    {

        Task<Cart> GetCartByCustomerIdAsync(Guid _id);
       
        Task<string> ClearCartAsync(Guid _id);
    }
}
