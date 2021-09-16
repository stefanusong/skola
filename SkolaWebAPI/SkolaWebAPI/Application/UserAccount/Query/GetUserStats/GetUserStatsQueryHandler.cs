using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Query.GetUserStats
{
    public class GetUserStatsQueryHandler : IRequestHandler<GetUserStatsQuery, GetUserStatsQueryResult>
    {
        private readonly SkolaDbContext _dbContext;

        public GetUserStatsQueryHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GetUserStatsQueryResult> Handle(GetUserStatsQuery request, CancellationToken cancellationToken)
        {
            var terms = await _dbContext.Terms
                .Where(x => x.UserId == request.userId)
                .Include(term => term.subjects)
                .ThenInclude(subject => subject.Tasks)
                .ToListAsync();
            GetUserStatsQueryResult result = calculateStats(terms);

            
            return result;
        }

        public GetUserStatsQueryResult calculateStats(List<Term> terms)
        {
            int totalSubjects = 0, totalTasks = 0, totalCompleted = 0, totalIncomplete = 0, 
                totalArchived = 0, totalActiveTasks = 0;
            
            foreach (var term in terms)
            {
                totalSubjects += term.subjects.Count();
                foreach (var subject in term.subjects)
                {
                    totalTasks += subject.Tasks.Count();
                    foreach (var task in subject.Tasks)
                    {
                        if (!task.isArchived)
                        {
                            totalActiveTasks += 1;
                            if (task.isCompleted)
                            {
                                totalCompleted += 1;
                            }
                            else if (!task.isCompleted)
                            {
                                totalIncomplete += 1;
                            }
                        }
                        else
                        {
                            totalArchived += 1;
                        }
                    }
                }
            }

            double onProgressPercentage, completedPercentage;

            onProgressPercentage = (Convert.ToDouble(totalIncomplete) / Convert.ToDouble(totalActiveTasks)) * 100;
            completedPercentage = (Convert.ToDouble(totalCompleted) / Convert.ToDouble(totalActiveTasks)) * 100;

            GetUserStatsQueryResult stats = new GetUserStatsQueryResult()
            {
                totalTerms = terms.Count(),
                totalSubjects = totalSubjects,
                totalTasks = totalTasks,
                totalActiveTasks = totalActiveTasks,
                totalCompleted = totalCompleted,
                totalIncomplete = totalIncomplete,
                totalArchived = totalArchived,
                onProgressPercentage = Math.Round(onProgressPercentage),
                completedPercentage = Math.Round(completedPercentage)
        };

            return stats;
        }
    }
}
