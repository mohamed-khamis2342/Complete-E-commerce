using E_commerce.Core.Commends.Category;
using E_commerce.Core.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly IMediator _mediator;
        public Category(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCategoryByIdQuery _id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_id);
            return Ok(result);
        }
        [HttpGet("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] DeleteCtegoryByIdCommend _id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(_id);
            return Ok(result);
        }

        [HttpPost("CreateCategory")]

        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommend _category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(_category);

            return Ok(result);

        }




        [HttpPost("UpdateCategory")]

        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommend _category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(_category);

            return Ok(result);

        }









    }
}
