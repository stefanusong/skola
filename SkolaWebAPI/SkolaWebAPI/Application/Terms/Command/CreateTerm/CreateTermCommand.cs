using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Terms.Command.CreateTerm
{
    public class CreateTermCommand : IRequest<Guid>
    {
        public string UserId { get; set; }
        public int Grade { get; set; }
        public Database.Entities.DepartmentType Department { get; set; }
    }
}
