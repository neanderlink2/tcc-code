﻿using Microsoft.EntityFrameworkCore;

namespace ProgramAcad.Infra.Data.Context
{
    public class ProgramAcadContext : DbContext
    {
        public ProgramAcadContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);

        }
    }
}
