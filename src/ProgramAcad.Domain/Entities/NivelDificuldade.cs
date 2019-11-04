using System.Collections.Generic;

namespace ProgramAcad.Domain.Entities
{
    public class NivelDificuldade
    {
        public NivelDificuldade(int id, int nivel, string descricao)
        {
            Id = id;
            Nivel = nivel;
            Descricao = descricao;
        }

        public int Id { get; protected set; }
        public int Nivel { get; protected set; }
        public string Descricao { get; protected set; }

        public ICollection<Algoritmo> AlgoritmosDesseNivel { get; set; }
        public ICollection<ExecucaoTeste> TestesExecutados { get; set; }
    }
}
