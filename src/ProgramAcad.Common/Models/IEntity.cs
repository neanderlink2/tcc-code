using System;

namespace ProgramAcad.Common.Models
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime DataCriacao { get; }
        bool Status { get; }
    }
}
