using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Query.GetSubjectByTerm
{
    public class GetSubjectByTermQueryHandler : IRequestHandler<GetSubjectByTermQuery, List<Subject>>
    {
        private readonly SkolaDbContext _dbContext;

        public GetSubjectByTermQueryHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Subject>> Handle(GetSubjectByTermQuery request, CancellationToken cancellationToken)
        {
            var response = _dbContext.Subjects.Where(x => x.termId == request.termId).ToList();
            return Task.FromResult(response);
        }
    }
}
