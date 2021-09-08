using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.DeleteTask
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public Guid taskId { get; set; }

        public DeleteTaskCommand(Guid taskId)
        {
            this.taskId = taskId;
        }
    }
}
