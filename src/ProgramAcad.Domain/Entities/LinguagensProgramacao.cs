using ProgramAcad.Common.Attributes;
using System.ComponentModel;

namespace ProgramAcad.Domain.Entities
{
    public enum LinguagensProgramacao
    {
        [Description("csharp")]
        [CompilerType("2")]
        CSharp = 1,

        [Description("python3")]
        [CompilerType("1")]
        Python = 2,

        [Description("c")]
        [CompilerType("2")]
        C = 3,

        [Description("java")]
        [CompilerType("2")]
        Java = 4
    }
}
