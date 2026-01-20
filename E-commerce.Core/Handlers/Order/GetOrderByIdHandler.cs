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
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderResponseDTO>>
    {
        private readonly IOrderService _orderService;

        public GetOrderByIdHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<ApiResponse<OrderResponseDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var OrderFromDb = await _orderService.GetOrderByID(request.OrderId);

            if(OrderFromDb ==null)
                return new ApiResponse<OrderResponseDTO>(400,"Order not Found");


            var orderResponse = MapOrderToDTO(OrderFromDb, OrderFromDb.Customer, OrderFromDb.BillingAddress, OrderFromDb.ShippingAddress);
            return new ApiResponse<OrderResponseDTO>(200, orderResponse);
        }


        private OrderResponseDTO MapOrderToDTO(Entities.Order order, Entities.Customer customer, Entities.Address billingAddress, Entities.Address shippingAddress)
        {

            var orderItemsDto = order.OrderItems.Select(oi => new OrderItemResponseDTO
            {
                Id = oi.Id,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice,
                Discount = oi.Discount,
                TotalPrice = oi.TotalPrice
            }).ToList();
        
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
