using E_commerce.Core.DTOs.Product;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Queries.Product
{
    public class GetAllProductsQuery:IRequest<ApiResponse<List<ProductResponseDTO>>>
    {
    }
}
