using System;

namespace ProgramAcad.Domain.Entities
{
    public class CasoTeste
    {
        public CasoTeste(string entradaEsperada, string saidaEsperada, int tempoDeExecucao, Guid idAlgoritmo)
        {
            EntradaEsperada = entradaEsperada;
            SaidaEsperada = saidaEsperada;
            TempoDeExecucao = tempoDeExecucao;
            IdAlgoritmo = idAlgoritmo;
        }

        public string EntradaEsperada { get; protected set; }
        public string SaidaEsperada { get; protected set; }
        public int TempoDeExecucao { get; protected set; }
        public Guid IdAlgoritmo { get; protected set; }

        public Algoritmo AlgoritmoVinculado { get; set; }
    }
}
