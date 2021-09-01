using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Command.CreateSubject
{
    public class CreateSubjectCommand : IRequest<Guid>
    {
        public Guid termId { get; set; }
        public string subjectName { get; set; }

    }
}
