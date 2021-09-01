using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Query.GetTermByUserId
{
    public class GetTermByUserIdQuery : IRequest<List<Term>>
    {
        public GetTermByUserIdQuery(string userId)
        {
            this.userId = userId;
        }

        public string userId { get; set; }
    }
}
