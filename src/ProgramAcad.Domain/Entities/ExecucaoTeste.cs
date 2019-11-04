﻿using System;

namespace ProgramAcad.Domain.Entities
{
    public class ExecucaoTeste
    {
        public ExecucaoTeste(Guid idCasoTeste, Guid idUsuario, LinguagensProgramacao idLinguagem, 
            bool sucesso, int tempoExecucao)
        {
            IdCasoTeste = idCasoTeste;
            IdUsuario = idUsuario;
            IdLinguagem = idLinguagem;
            Sucesso = sucesso;
            TempoExecucao = tempoExecucao;
        }

        public Guid IdCasoTeste { get; protected set; }
        public Guid IdUsuario { get; protected set; }
        public LinguagensProgramacao IdLinguagem { get; protected set; }
        public bool Sucesso { get; protected set; }
        public int TempoExecucao { get; protected set; }


        public CasoTeste CasoTeste { get; set; }
        public Usuario UsuarioExecutou { get; set; }
    }
}
