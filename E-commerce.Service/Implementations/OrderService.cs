using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository  orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task<Order> CreatOrderAsync(Order _order)
        {
            var Order = await _orderRepository.AddAsync(_order);

                return Order;   
        }

        public async Task<IEnumerable<Order>> GetAllAsAsync()
        {
           return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByID(Guid _OderID)
        {
           var OrderFromDb = await _orderRepository.GetByIdAsync(_OderID);  

            return OrderFromDb;
        }

        public Task<string> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
