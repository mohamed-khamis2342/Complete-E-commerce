using E_commerce.Core.Commends.Auth;
using E_commerce.Core.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        public IMediator _mediator;

        public Account(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommend registerFromReq) { 

            var result = await _mediator.Send(registerFromReq);

            return Ok(result);
       
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommend _loginFromReq) { 

            var result = await _mediator.Send(_loginFromReq);

            return Ok(result);
       
        }
        [HttpPost("CheckRefreshToken")]
        public async Task<IActionResult> CheckRefreshToken([FromBody] RefreshTokenCommend _tokenFromReq) { 

            var result = await _mediator.Send(_tokenFromReq);

            return Ok(result);
       
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleCommend _roleFromReq) { 

            var result = await _mediator.Send(_roleFromReq);

            return Ok(result);
       
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommend _updateUserFromReq) { 

            var result = await _mediator.Send(_updateUserFromReq);
            if(string.IsNullOrEmpty(result))
            return Ok("Updated successfully");


            return BadRequest("something went wrong");
       
        }


        [HttpGet("GetUserById")]

        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery _id)  {

            var result = await _mediator.Send(_id);

           if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Something went wrong");

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommend _chngPass)
        {
            var result = await _mediator.Send(_chngPass);

            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok("Updated Successfully");

        }





    }
}
