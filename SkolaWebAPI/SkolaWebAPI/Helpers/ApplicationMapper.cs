using AutoMapper;
using SkolaWebAPI.Application.Subjects.Command.CreateSubject;
using SkolaWebAPI.Application.Terms.Command.CreateTerm;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CreateTermCommand, Term>();
            CreateMap<CreateSubjectCommand, Subject>();
        }
    }
}
