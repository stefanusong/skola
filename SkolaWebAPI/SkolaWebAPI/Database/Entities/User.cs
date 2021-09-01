using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Term> Terms { get; set; }
    }
}
