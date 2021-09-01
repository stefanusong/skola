using AutoMapper;
using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Command.CreateTerm
{
    public class CreateTermCommandHandler : IRequestHandler<CreateTermCommand, Guid>
    {
        private readonly SkolaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateTermCommandHandler(SkolaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateTermCommand request, CancellationToken cancellationToken)
        {
            var term = _mapper.Map<Term>(request);
            await _dbContext.Terms.AddAsync(term, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return term.TermId;
        }
    }
}
