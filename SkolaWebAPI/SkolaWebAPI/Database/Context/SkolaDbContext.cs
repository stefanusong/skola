using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkolaWebAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Context
{
    public class SkolaDbContext : IdentityDbContext<User>
    {
        public SkolaDbContext(DbContextOptions<SkolaDbContext> options) : base(options) {}

        public DbSet<Term> Terms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
