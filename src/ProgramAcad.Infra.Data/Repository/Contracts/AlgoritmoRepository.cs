﻿using ProgramAcad.Domain.Contracts.Repositories;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Infra.Data.Context;

namespace ProgramAcad.Infra.Data.Repository.Contracts
{
    public class AlgoritmoRepository : Repository<Algoritmo>, IAlgoritmoRepository
    {
        public AlgoritmoRepository(ProgramAcadContext dbContext) : base(dbContext)
        {
        }
    }
}
