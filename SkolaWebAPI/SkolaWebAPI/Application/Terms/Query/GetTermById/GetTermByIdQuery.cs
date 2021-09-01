using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Query.GetTermById
{
    public class GetTermByIdQuery : IRequest<Term>
    {
        public GetTermByIdQuery(Guid termId)
        {
            TermId = termId;
        }

        public Guid TermId { get; set; }

    }
}
