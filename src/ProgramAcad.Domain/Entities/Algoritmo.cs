using ProgramAcad.Common.Models;
using System;
using System.Collections.Generic;

namespace ProgramAcad.Domain.Entities
{
    public class Algoritmo
    {
        public Algoritmo(string titulo, string htmlDescricao, int idNivelDificuldade)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Titulo = titulo;
            HtmlDescricao = htmlDescricao;
            IdNivelDificuldade = idNivelDificuldade;
        }

        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public string Titulo { get; protected set; }
        public string HtmlDescricao { get; protected set; }
        public int IdNivelDificuldade { get; protected set; }

        public NivelDificuldade NivelDificuldade { get; set; }

        public ICollection<CasoTeste> CasosDeTeste { get; set; }
        public ICollection<AlgoritmoLinguagemDisponivel> LinguagensPermitidas { get; set; }
        public ICollection<AlgoritmoResolvido> AlgoritmosResolvidos { get; set; }
    }
}
