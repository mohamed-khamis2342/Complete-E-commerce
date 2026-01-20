using E_commerce.Core.Commends.Order;
using E_commerce.Core.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order : ControllerBase
    {
        private readonly IMediator _mediator;

        public Order(IMediator mediator)
        {
            this._mediator = mediator;
        }



        [HttpPost("CreatOrder")]

        public async Task<IActionResult> ActionResult([FromBody] CreatOrderCommend _order) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(_order);

             return Ok(result);
              
        }
        [HttpGet("GetOrderByID")]

        public async Task<IActionResult> GetOrderByID([FromQuery] GetOrderByIdQuery _id ) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(_id);

             return Ok(result);
              
        }
        [HttpGet("GetAllOrder")]

        public async Task<IActionResult> GetAllOrder( ) {

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new GetAllOrdersQuery());

             return Ok(result);
              
        }
    }
}
