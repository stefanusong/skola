using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkolaWebAPI.Application.Subjects.Command.CreateSubject;
using SkolaWebAPI.Application.Subjects.Query.GetSubjectByTerm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectCommand body)
        {
            var response = await _mediator.Send(body);
            if(response == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet("{termId}")]
        public async Task<IActionResult> GetSubjectByTerm([FromRoute] Guid termId)
        {
            var response = await _mediator.Send(new GetSubjectByTermQuery(termId));
            return Ok(response);
        }
    }
}
