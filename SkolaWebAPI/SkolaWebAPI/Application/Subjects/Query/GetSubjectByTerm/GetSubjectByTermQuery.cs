using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Query.GetSubjectByTerm
{
    public class GetSubjectByTermQuery : IRequest<List<Subject>>
    {
        public GetSubjectByTermQuery(Guid termId)
        {
            this.termId = termId;
        }

        public Guid termId { get; set; }
    }
}
