using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.EditTask
{
    public class EditTaskCommand : IRequest<bool>
    {
        public EditTaskCommand(Guid taskId, string taskName)
        {
            this.taskId = taskId;
            this.taskName = taskName;
        }

        public Guid taskId { get; set; }
        public string taskName { get; set; }
    }
}
