using E_commerce.DTOs;
using E_commerce.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Commends.Auth
{
    public class RefreshTokenCommend:IRequest<ApiResponse<LoginResponseDTO>>
    {
      public string Token { get; set; }
    }
}
