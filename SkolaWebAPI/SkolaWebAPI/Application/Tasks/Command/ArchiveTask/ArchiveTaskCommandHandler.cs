using MediatR;
using SkolaWebAPI.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.ArchiveTask
{
    public class ArchiveTaskCommandHandler : IRequestHandler<ArchiveTaskCommand, bool>
    {
        private readonly SkolaDbContext _dbContext;

        public ArchiveTaskCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(ArchiveTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(request.taskId);

            if(task == null)
            {
                return false;
            }

            task.isArchived = !task.isArchived;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
