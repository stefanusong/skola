using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.ArchiveTask
{
    public class ArchiveTaskCommand : IRequest<bool>
    {
        public Guid taskId { get; set; }

        public ArchiveTaskCommand(Guid taskId)
        {
            this.taskId = taskId;
        }
    }
}
