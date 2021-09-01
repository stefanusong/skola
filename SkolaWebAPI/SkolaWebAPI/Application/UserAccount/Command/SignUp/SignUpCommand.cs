using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Application.UserAccount.Command.SignUp
{
    public class SignUpCommand : IRequest<IdentityResult>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmedPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }
    }
}
