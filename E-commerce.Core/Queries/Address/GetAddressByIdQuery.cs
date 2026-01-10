using E_commerce.Core.DTOs.Address;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Queries.Address
{
    public class GetAddressByIdQuery: IRequest<ApiResponse<AddressResponseDTO>>
    {
        [Required]
        public int Id { get; set; }
    }
}
