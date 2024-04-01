using Desafio_Funcionario.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Desafio_Funcionario.Context
{
    public class FuncionarioContext : DbContext
    {
        public readonly string _conexao;

        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {
            
        }

        public DbSet<Funcioario> FuncionariosNovos {  get; set; }
        public DbSet<LogAlteracoes> LogAlteracoes { get; set; }

    }
}
