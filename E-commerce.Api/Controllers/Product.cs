using E_commerce.Core.Commends.Product;
using E_commerce.Core.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IMediator _mediator;

        public Product(IMediator mediator)
        {
            this._mediator = mediator;
        }






        [HttpGet("AllProducts")]

        public async Task<IActionResult> AllProducts() {

            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        
        
        
        }







        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommend _product) {


            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _mediator.Send(_product);


            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQuery _id) {


            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _mediator.Send(_id);


            return Ok(result);
        }

        [HttpPut("updateProduct")]

        public async Task<IActionResult> updateProduct([FromBody] UpdateProductCommend _product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_product);
            return Ok(result);

        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductCommend _id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(_id);

            return Ok(result);

        }

    }
}
