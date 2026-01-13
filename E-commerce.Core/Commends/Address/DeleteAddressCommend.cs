using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Address
{
    public class DeleteAddressCommend:IRequest<ApiResponse<string>>
    {
        [Required(ErrorMessage = "CustomerId is Required")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "AddressId is Required")]
        public Guid AddressId { get; set; }
    }
}
