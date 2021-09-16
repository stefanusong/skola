using MediatR;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<SubjectTask>> Handle(GetArchivedTaskCommand request, CancellationToken cancellationToken)
        {
            var terms = await _dbContext.Terms
                .Where(x => x.UserId == request.userId)
                .Include(term => term.subjects)
                .ThenInclude(subject => subject.Tasks.Where(task => task.isArchived == true))
                .ToListAsync();

            List<SubjectTask> tasks = new List<SubjectTask>();

            foreach(var term in terms)
            {
                foreach(var subject in term.subjects)
                {
                    tasks.AddRange(subject.Tasks);
                }
            }
            
            return tasks;
        }
    }
}
