using E_commerce.Core.DTOs.AuthDTOs;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Queries.User
{
    public class GetUserByIdQuery:IRequest<ApiResponse<UpdateResponseDTO>>
    {
    public string UserId { get; set; }    
    }
}
