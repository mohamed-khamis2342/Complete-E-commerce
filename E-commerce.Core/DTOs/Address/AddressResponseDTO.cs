using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.DTOs.Address
{
    public class AddressResponseDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
