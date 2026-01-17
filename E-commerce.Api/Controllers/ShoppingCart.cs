using E_commerce.Core.Commends.Cart;
using E_commerce.Core.Handlers.Cart;
using E_commerce.Core.Queries.ShoppingCart;
using E_commerce.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCart : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCart(IMediator mediator)
        {
            this._mediator = mediator;
        }



        [HttpGet("GetCartByID")]
        public async Task<IActionResult> CartById([FromQuery] GetCartByCustomerIdQuery  _id )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_id);

            return Ok(result);

        }
        [HttpPost("AddToCart")]

        public async Task<IActionResult> AddToCart([FromBody] AddToCartCommend _cart)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_cart);
            return Ok(result);

        }



        [HttpPut("UpdateCartItem")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemCommend _update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_update);
            return Ok(result);
        }
        [HttpDelete("RemoveCartItem")]
        public async Task<IActionResult> RemoveCartItem([FromBody] RemoveCartItemCommend _Remover)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_Remover);
            return Ok(result);
        }
        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart([FromBody] ClearCartCommend Clear)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(Clear);
            return Ok(result);
        }
    }
}
