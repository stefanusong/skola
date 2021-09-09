using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Command.EditSubject
{
    public class EditSubjectCommand : IRequest<bool>
    {
        public EditSubjectCommand(Guid subjectId, string subjectName)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
        }
        public Guid subjectId { get; set; }
        public string subjectName { get; set; }
    }
}
