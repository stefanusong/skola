using MediatR;
using SkolaWebAPI.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.SetCompleteStatus
{
    public class SetCompleteStatusCommandHandler : IRequestHandler<SetCompleteStatusCommand, bool>
    {
        private readonly SkolaDbContext _dbContext;

        public SetCompleteStatusCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(SetCompleteStatusCommand request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.Tasks.FindAsync(request.taskId);

            if(res == null)
            {
                return false;
            }

            res.isCompleted = !res.isCompleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
