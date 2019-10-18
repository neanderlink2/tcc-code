namespace ProgramAcad.PoC.Compiler.JDoodle.Models
{
    public class CompilerResponse
    {
        public string Output { get; set; }
        public int StatusCode { get; set; }
        public double? CpuTime { get; set; }

        public bool HasCompilingError => CpuTime == null || (Output != null && Output.Contains("Traceback (most recent call last)"));
    }
}
