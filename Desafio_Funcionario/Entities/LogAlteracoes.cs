namespace Desafio_Funcionario.Entities
{
    public class LogAlteracoes
    {
        public int Id { get; set; }
        public int CodigoRegistro { get; set; }
        public string TipoOperacao { get; set; } = string.Empty;
        public string Tabela { get; set; } = string.Empty;
        public DateTime DataAlteracao { get; set; }
        public string Xml { get; set; } = string.Empty;
    }
}
