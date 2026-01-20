using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsAsync();
        Task<Order> CreatOrderAsync(Order order);

        Task<Order> GetOrderByID(Guid _OderID);

        //Task<Order> GetCartByCustomerIdAsync(Guid id);
        Task<string> UpdateOrderAsync(Order order);

        //Task<string> ClearCartAsync(Order cart);
        //Task<string> RemoveCartItemAsync(Order  cart);
    }
}
