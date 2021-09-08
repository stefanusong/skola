using MediatR;
using SkolaWebAPI.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.EditTask
{
    public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, bool>
    {
        private readonly SkolaDbContext _dbContext;

        public EditTaskCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(request.taskId);
            if(task == null)
            {
                return false;
            }
            task.TaskName = request.taskName;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
