using AutoMapper;
using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Subjects.Command.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Guid>
    {
        private readonly SkolaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateSubjectCommandHandler(SkolaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request);
            await _dbContext.AddAsync(subject);
            await _dbContext.SaveChangesAsync();
            return subject.subjectId;
        }
    }
}
