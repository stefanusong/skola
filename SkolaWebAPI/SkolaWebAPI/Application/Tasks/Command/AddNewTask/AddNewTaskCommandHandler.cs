using AutoMapper;
using MediatR;
using SkolaWebAPI.Database.Context;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.Tasks.Command.AddNewTask
{
    public class AddNewTaskCommandHandler : IRequestHandler<AddNewTaskCommand, Guid>
    {
        private readonly SkolaDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddNewTaskCommandHandler(SkolaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(AddNewTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<SubjectTask>(request);
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task.TaskId;
        }
    }
}
