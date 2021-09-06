using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Query.GetTaskBySubject
{
    public class GetTaskBySubjectCommandHandler : IRequestHandler<GetTaskBySubjectCommand, List<SubjectTask>>
    {
        private readonly SkolaDbContext _dbContext;

        public GetTaskBySubjectCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<SubjectTask>> Handle(GetTaskBySubjectCommand request, CancellationToken cancellationToken)
        {
            var res = _dbContext.Tasks.Where(x => x.subjectId == request.subjectId).ToList();
            return Task.FromResult(res);
        }
    }
}
