using ProgramAcad.Domain.Contracts.Repositories;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Infra.Data.Context;

namespace ProgramAcad.Infra.Data.Repository.Contracts
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ProgramAcadContext dbContext) : base(dbContext)
        {
        }
    }
}
