using System.ComponentModel;

namespace ProgramAcad.Common.Enums
{
    public enum LinguagensProgramacao
    {
        [Description("csharp")]
        [AmbientValue("2")]
        CSharp = 1,

        [Description("python3")]
        [AmbientValue("1")]
        Python = 2,

        [Description("c")]
        [AmbientValue("2")]
        C = 3,

        [Description("java")]
        [AmbientValue("2")]
        Java = 4
    }
}
