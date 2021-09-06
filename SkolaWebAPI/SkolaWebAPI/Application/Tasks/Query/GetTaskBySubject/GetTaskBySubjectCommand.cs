using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Query.GetTaskBySubject
{
    public class GetTaskBySubjectCommand : IRequest<List<SubjectTask>>
    {
        public GetTaskBySubjectCommand(Guid Id)
        {
            subjectId = Id;
        }
        public Guid subjectId { get; set; }
    }
}
