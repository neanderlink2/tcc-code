using Microsoft.AspNetCore.Identity;
using ProgramAcad.Common.Models;
using System;

namespace ProgramAcad.Domain.Entities
{
    public class Usuario : IdentityUser<Guid>, IEntity
    {
        public DateTime DataCriacao { get; protected set; }
        public bool Status { get; protected set; }
    }
}
