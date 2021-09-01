using MediatR;
using Microsoft.AspNetCore.Identity;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Query
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly UserManager<User> _userManager;

        public GetUserByEmailQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _userManager.FindByEmailAsync(request.Email);
            return response;
        }
    }
}
