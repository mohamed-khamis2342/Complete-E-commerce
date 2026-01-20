using E_commerce.Core.DTOs.Order;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Queries.Order
{
    public class GetAllOrdersQuery:IRequest<ApiResponse<List<OrderResponseDTO>>>
    {
    }
}
