using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgramAcad.Domain.Entities;
using System;

namespace ProgramAcad.Infra.Data.Context
{
    public class ProgramAcadContext : IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>
    {
        public ProgramAcadContext(DbContextOptions options) : base(options)
        {
        }
    }
}
