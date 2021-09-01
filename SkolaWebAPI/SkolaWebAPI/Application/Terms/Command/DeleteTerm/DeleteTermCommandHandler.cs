using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Command.DeleteTerm
{
    public class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand, Guid>
    {
        private readonly SkolaDbContext _dbContext;

        public DeleteTermCommandHandler(SkolaDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Guid> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
        {
            var deletedTerm = new Term { TermId = request.TermId };
            _dbContext.Terms.Remove(deletedTerm);
            await _dbContext.SaveChangesAsync();
            return request.TermId;
        }
    }
}
