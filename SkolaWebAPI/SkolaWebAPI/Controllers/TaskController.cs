using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkolaWebAPI.Application.Tasks.Command.AddNewTask;
using SkolaWebAPI.Application.Tasks.Query.GetTaskBySubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> addNewTask([FromBody] AddNewTaskCommand body)
        {
            var res = await _mediator.Send(body);
            if(res == Guid.Empty)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("{subjectId}")]
        public async Task<IActionResult> getTaskBySubject([FromRoute] Guid subjectId)
        {
            var res = await _mediator.Send(new GetTaskBySubjectCommand(subjectId));
            if(res == null)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
