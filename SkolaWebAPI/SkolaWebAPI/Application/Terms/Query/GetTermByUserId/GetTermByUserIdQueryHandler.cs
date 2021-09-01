using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Query.GetTermByUserId
{
    public class GetTermByUserIdQueryHandler : IRequestHandler<GetTermByUserIdQuery, List<Term>>
    {
        private readonly SkolaDbContext _dbContext;

        public GetTermByUserIdQueryHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Term>> Handle(GetTermByUserIdQuery request, CancellationToken cancellationToken)
        {
            var term =  _dbContext.Terms.Where(x => x.UserId == request.userId).OrderBy(y => y.Department).ThenBy(z => z.Grade).ToList();
            return Task.FromResult(term);
        }
    }
}
