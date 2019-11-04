using ProgramAcad.Domain.Contracts.Repositories;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Infra.Data.Context;

namespace ProgramAcad.Infra.Data.Repository.Contracts
{
    public class AlgoritmoResolvidoRepository : Repository<AlgoritmoResolvido>, IAlgoritmoResolvidoRepository
    {
        public AlgoritmoResolvidoRepository(ProgramAcadContext dbContext) : base(dbContext)
        {
        }
    }
}
