using System.ComponentModel.DataAnnotations;

namespace Desafio_Funcionario.Entities
{
    public class Funcioario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Ramal { get; set; } = string.Empty;
        public string EmailProfissional { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Salario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
