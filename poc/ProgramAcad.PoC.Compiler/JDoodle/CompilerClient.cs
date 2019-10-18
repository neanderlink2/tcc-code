using Newtonsoft.Json;
using ProgramAcad.Common.Enums;
using ProgramAcad.Common.Extensions;
using ProgramAcad.PoC.Compiler.JDoodle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProgramAcad.PoC.Compiler
{
    public class CompilerClient
    {
        private readonly HttpClient _httpClient;

        public CompilerClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.jdoodle.com/v1")
            };
        }

        public async Task<CompilerResponse> Compile(string code, IEnumerable<string> entradas, LinguagensProgramacao language)
        {
            var options = JsonConvert.SerializeObject(new CompilerOptions()
            {
                ClientId = "429fb7480ce5cb918fe31f3d35a92b98",
                ClientSecret = "7767df95c98ee926cd2ec533b306532aa58c2eae40527c26f726e20d087cc507",
                Linguagem = language.GetDescription(),
                Script = code,
                Versao = language.GetAmbientValue(),
                Entradas = entradas.Aggregate((prev, str) => $"{prev}\n{str}")
            });

            var content = new StringContent(options);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/execute", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new CompilingFailedException(JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync()));
            }

            return JsonConvert.DeserializeObject<CompilerResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
