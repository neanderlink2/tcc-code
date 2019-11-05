using Microsoft.AspNetCore.Mvc;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Services.Interfaces.Clients;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgramAcad.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/compiler")]
    [Produces("application/json")]
    public class CompilerController : ControllerBase
    {
        private readonly ICompilerApiClient _compilerApiClient;

        public CompilerController(ICompilerApiClient compilerApiClient)
        {
            _compilerApiClient = compilerApiClient;
        }

        /// <summary>
        /// Compila o código para C# e retorna a saída.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpPost("csharp")]
        public async Task<IActionResult> CompileCSharp([FromForm]string code, [FromForm]string[] inputs)
        {
            var output = await _compilerApiClient.Compile(code, inputs, LinguagensProgramacao.CSharp);
            return Ok(output);
        }
    }
}
