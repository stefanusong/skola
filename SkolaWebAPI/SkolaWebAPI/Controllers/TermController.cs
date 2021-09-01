using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkolaWebAPI.Application.Terms.Command.CreateTerm;
using SkolaWebAPI.Application.Terms.Command.DeleteTerm;
using SkolaWebAPI.Application.Terms.Query.GetTermById;
using SkolaWebAPI.Application.Terms.Query.GetTermByUserId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TermController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TermController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTerm([FromBody] CreateTermCommand body)
        {
            var response = await _mediator.Send(body);
            if(response == Guid.Empty)
            {
                return BadRequest();
            }
            var result = new
            {
                TermId = response,
                UserId = body.UserId,
                Grade = body.Grade,
                Department = body.Department
            };
            return CreatedAtAction(nameof(GetTermById), new { id = response}, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTermById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetTermByIdQuery(id));
            if(response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetTermByUserId([FromRoute] string userId)
        {
            var response = await _mediator.Send(new GetTermByUserIdQuery(userId));
            if(!response.Any())
            {
                return NotFound(new { error = "Not Found" });
            }
            return Ok(response);
        }

        [HttpDelete("{termId}")]
        public async Task<IActionResult> DeleteTermById([FromRoute] Guid termId)
        {
            var response = await _mediator.Send(new DeleteTermCommand(termId));
            return Ok(response);
        }
    }
}
