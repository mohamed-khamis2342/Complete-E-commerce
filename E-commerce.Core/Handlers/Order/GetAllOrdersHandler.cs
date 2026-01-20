using E_commerce.Core.DTOs.Order;
using E_commerce.Core.Queries.Order;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<OrderResponseDTO>>>
    {
        private readonly IOrderService _orderService;

        public GetAllOrdersHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<ApiResponse<List<OrderResponseDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _orderService.GetAllAsAsync();

            if (allOrders == null)
                return new ApiResponse<List<OrderResponseDTO>>(400,"Not found");



            // Map each order to its corresponding DTO.
            var orderList = allOrders.Select(o => MapOrderToDTO(o, o.Customer, o.BillingAddress, o.ShippingAddress)).ToList();
            return new ApiResponse<List<OrderResponseDTO>>(200, orderList);
        }


        private OrderResponseDTO MapOrderToDTO(Entities.Order order, Customer customer, Entities.Address billingAddress, Entities.Address shippingAddress)
        {
            // Map order items.
            var orderItemsDto = order.OrderItems.Select(oi => new OrderItemResponseDTO
            {
                Id = oi.Id,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice,
                Discount = oi.Discount,
                TotalPrice = oi.TotalPrice
            }).ToList();
            // Create and return the DTO.
            return new OrderResponseDTO
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId,
                BillingAddressId = order.BillingAddressId,
                ShippingAddressId = order.ShippingAddressId,
                TotalBaseAmount = order.TotalBaseAmount,
                TotalDiscountAmount = order.TotalDiscountAmount,
                ShippingCost = order.ShippingCost,
                TotalAmount = Math.Round(order.TotalAmount, 2),
                // OrderStatus = order.OrderStatus.ToString(),
                OrderItems = orderItemsDto
            };
        }
    }
}
