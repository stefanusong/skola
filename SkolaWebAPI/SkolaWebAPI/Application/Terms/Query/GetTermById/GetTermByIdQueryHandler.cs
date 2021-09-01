using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Query.GetTermById
{
    public class GetTermByIdQueryHandler : IRequestHandler<GetTermByIdQuery, Term>
    {
        private readonly SkolaDbContext _dbContext;

        public GetTermByIdQueryHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Term> Handle(GetTermByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Terms.FindAsync(request.TermId);
            return response;
        }
    }
}
