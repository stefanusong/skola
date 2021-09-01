using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkolaWebAPI.Application.UserAccount.Command.SignIn;
using SkolaWebAPI.Application.UserAccount.Command.SignUp;
using SkolaWebAPI.Application.UserAccount.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand body)
        {
            var response = await _mediator.Send(body);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return Unauthorized(response);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignUp([FromBody] SignInCommand body)
        {
            var response = await _mediator.Send(body);
            if (string.IsNullOrEmpty(response))
            {
                return Unauthorized(new { token = String.Empty });
            }
            return Ok(new { token =  response });
        }

        [Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            var response = await _mediator.Send(new GetUserByEmailQuery(email));
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
