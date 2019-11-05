using Newtonsoft.Json;
using ProgramAcad.Common.Extensions;
using ProgramAcad.Common.Models;
using ProgramAcad.Domain.Entities;
using ProgramAcad.Domain.Exceptions;
using ProgramAcad.Services.Interfaces.Clients;
using ProgramAcad.Services.Modules.Compiling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProgramAcad.Services.Modules.Compiling
{
    public class CompilerApiClient : ICompilerApiClient
    {
        private readonly HttpClient _httpClient;

        public CompilerApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.jdoodle.com/v1")
            };
        }

        public async Task<CompilerResponse> Compile(string code, IEnumerable<string> entradas, LinguagensProgramacao language)
        {
            var options = new CompilerOptions(
                "429fb7480ce5cb918fe31f3d35a92b98",
                "7767df95c98ee926cd2ec533b306532aa58c2eae40527c26f726e20d087cc507",
                code,
                language.GetDescription(),
                language.GetCompilerType(),
                entradas.Any() ? entradas.Aggregate((prev, str) => $"{prev}\n{str}") : "");
            var jsonOptions = JsonConvert.SerializeObject(options);

            var content = new StringContent(jsonOptions);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/execute", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new CompilingFailedException(JsonConvert.DeserializeObject<ExpectedError>(error));
            }

            return JsonConvert.DeserializeObject<CompilerResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
