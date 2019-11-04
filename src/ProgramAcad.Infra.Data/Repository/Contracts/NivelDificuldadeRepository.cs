using ProgramAcad.Domain.Contracts.Repositories;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Infra.Data.Context;

namespace ProgramAcad.Infra.Data.Repository.Contracts
{
    public class NivelDificuldadeRepository : Repository<NivelDificuldade>, INivelDificuldadeRepository
    {
        public NivelDificuldadeRepository(ProgramAcadContext dbContext) : base(dbContext)
        {
        }
    }
}
