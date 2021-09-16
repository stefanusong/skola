using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Query.GetUserStats
{
    public class GetUserStatsQueryResult
    {
        public int totalTerms { get; set; }
        public int totalSubjects { get; set; }
        public int totalTasks { get; set; }
        public int totalActiveTasks { get; set; }
        public int totalCompleted { get; set; }
        public int totalIncomplete { get; set; }
        public int totalArchived { get; set; }
        public double onProgressPercentage { get; set; }
        public double completedPercentage { get; set; }
    }
}
