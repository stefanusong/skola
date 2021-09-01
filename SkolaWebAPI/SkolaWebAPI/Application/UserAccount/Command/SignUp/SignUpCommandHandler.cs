using MediatR;
using Microsoft.AspNetCore.Identity;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Command.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;

        public SignUpCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Email
            };
            return await _userManager.CreateAsync(user, request.Password);
        }
    }
}
