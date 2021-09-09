using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Query.GetArchivedTask
{
    public class GetArchivedTaskCommand : IRequest<List<SubjectTask>>
    {
        public GetArchivedTaskCommand()
        {

        }
    }
}
