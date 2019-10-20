namespace ProgramAcad.Domain.Entities
{
    public class LinguagemProgramacao
    {
        public LinguagemProgramacao(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
    }
}
