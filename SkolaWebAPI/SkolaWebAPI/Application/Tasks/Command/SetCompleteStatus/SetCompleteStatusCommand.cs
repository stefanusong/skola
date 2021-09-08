using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.SetCompleteStatus
{
    public class SetCompleteStatusCommand : IRequest<bool>
    {
        public SetCompleteStatusCommand(Guid taskId)
        {
            this.taskId = taskId;
        }
        public Guid taskId { get; set; }
    }
}
