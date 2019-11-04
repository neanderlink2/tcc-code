using Microsoft.EntityFrameworkCore;

namespace ProgramAcad.Infra.Data.Context
{
    public class ProgramAcadContext : DbContext
    {
        public ProgramAcadContext(DbContextOptions options) : base(options)
        {
        }
    }
}
