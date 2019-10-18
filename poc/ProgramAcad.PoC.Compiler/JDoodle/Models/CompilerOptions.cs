using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProgramAcad.PoC.Compiler.JDoodle.Models
{
    public class CompilerOptions
    {
        /// <summary>
        /// Código identificador para utilizar a API
        /// </summary>
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Código secreto para utilizar a API.
        /// </summary>
        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Código que será executa.
        /// </summary>
        [JsonProperty("script")]
        public string Script { get; set; }

        /// <summary>
        /// Linguagem de programação
        /// </summary>
        [JsonProperty("language")]
        public string Linguagem { get; set; }

        /// <summary>
        /// Versão do compilador
        /// </summary>
        [JsonProperty("versionIndex")]
        public string Versao { get; set; }

        /// <summary>
        /// Entradas para o algoritmo. Cada entrada deve estar separada por \n.
        /// </summary>
        [JsonProperty("stdin")]
        public string Entradas { get; set; }
    }
}
