using MediatR;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Query
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public GetUserByEmailQuery(string email)
        {
            this.Email = email;
        }
        public string Email { get; set; }
    }
}
