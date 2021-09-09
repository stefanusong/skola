using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Command.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest<bool>
    {
        public Guid subjectId { get; set; }

        public DeleteSubjectCommand(Guid subjectId)
        {
            this.subjectId = subjectId;
        }
    }
}
