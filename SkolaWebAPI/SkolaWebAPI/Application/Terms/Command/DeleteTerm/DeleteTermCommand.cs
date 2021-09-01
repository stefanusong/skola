using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Command.DeleteTerm
{
    public class DeleteTermCommand : IRequest<Guid>
    {
        public DeleteTermCommand(Guid termId)
        {
            TermId = termId;
        }

        public Guid TermId { get; set; }
    }
}
