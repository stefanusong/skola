using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Query.GetArchivedTask
{
    public class GetArchivedTaskCommandHandler : IRequestHandler<GetArchivedTaskCommand, List<SubjectTask>>
    {
        private readonly SkolaDbContext _dbContext;

        public GetArchivedTaskCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<SubjectTask>> Handle(GetArchivedTaskCommand request, CancellationToken cancellationToken)
        {
            var res = _dbContext.Tasks.Where(x => x.isArchived == true).ToList();
            return Task.FromResult(res);
        }
    }
}
