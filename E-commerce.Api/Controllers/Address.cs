using E_commerce.Core.Commends.Address;
using E_commerce.Core.Queries.Address;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Address : ControllerBase
    {
        private readonly IMediator _mediator;

        public Address(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateAddress")]

        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommend _address)
        {
            var result = await _mediator.Send(_address);
            return Ok(result);
        }

        [HttpGet("GetAddressById")]

        public async Task<IActionResult> GetAddressById([FromQuery] GetAddressByIdQuery id) {

            var result = await _mediator.Send(id);  


            return Ok(result);
        }
        [HttpPost("UpdateAddress")]
        public async Task <IActionResult> UpdateAddress([FromBody]UpdateAddressCommend _address)  
        {
            var result = await _mediator.Send(_address);

            return Ok(result);
        }
        [HttpPost("DeleteAddress")]
        public async Task <IActionResult> DeleteAddress([FromBody]DeleteAddressCommend _address)  
        {
            var result = await _mediator.Send(_address);

            return Ok(result);
        }



    }
}
