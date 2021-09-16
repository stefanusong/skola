using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Query.GetUserStats
{
    public class GetUserStatsQuery : IRequest<GetUserStatsQueryResult>
    {
        public GetUserStatsQuery(string userId)
        {
            this.userId = userId;
        }
        public string userId { get; set; }
    }
}
