using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.AddNewTask
{
    public class AddNewTaskCommand : IRequest<Guid>
    {
        public Guid subjectId { get; set; }
        public string TaskName { get; set; }
    }
}
