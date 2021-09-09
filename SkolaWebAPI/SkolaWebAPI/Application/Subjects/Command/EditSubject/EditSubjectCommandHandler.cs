using MediatR;
using SkolaWebAPI.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Command.EditSubject
{
    public class EditSubjectCommandHandler : IRequestHandler<EditSubjectCommand, bool>
    {
        private readonly SkolaDbContext _dbContext;

        public EditSubjectCommandHandler(SkolaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = await _dbContext.Subjects.FindAsync(request.subjectId);
            if(subject == null)
            {
                return false;
            }
            subject.subjectName = request.subjectName;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
