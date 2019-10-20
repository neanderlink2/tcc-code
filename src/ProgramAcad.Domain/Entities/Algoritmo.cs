using ProgramAcad.Common.Models;

namespace ProgramAcad.Domain.Entities
{
    public class Algoritmo : Entity
    {
        public Algoritmo(string titulo, string htmlDescricao, int idNivelDificuldade)
        {
            Titulo = titulo;
            HtmlDescricao = htmlDescricao;
            IdNivelDificuldade = idNivelDificuldade;
        }

        public string Titulo { get; protected set; }
        public string HtmlDescricao { get; protected set; }
        public int IdNivelDificuldade { get; protected set; }

        public NivelDificuldade NivelDificuldade { get; set; }
    }
}
