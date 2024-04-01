using Desafio_Funcionario.Context;
using Desafio_Funcionario.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Desafio_Funcionario.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioContext _conexao;

        public FuncionarioController(FuncionarioContext controler)
        {
                _conexao = controler;
        }

        public static void AdicionarLog(int CodigoRegistro, string TipoOperacao, string Tabela, string XML, FuncionarioContext context)
        {
            var NovoLog = new LogAlteracoes
            {
                CodigoRegistro = CodigoRegistro,
                TipoOperacao = TipoOperacao,
                Tabela = Tabela,
                DataAlteracao = DateTime.Now,
                Xml = XML
            };

            context.LogAlteracoes.Add(NovoLog);
            context.SaveChanges();
        }



        [HttpPost("Incluir")]
        public IActionResult IncluirFuncionario(Funcioario funcioario)
        {
            var FuncionarioBanco = _conexao.FuncionariosNovos.Find(funcioario.Id);
            if(FuncionarioBanco == null)
            {
                _conexao.FuncionariosNovos.Add(funcioario);
                _conexao.SaveChanges();

                AdicionarLog(funcioario.Id, "Incluir", "FuncionariosNovos", JsonSerializer.Serialize(funcioario), _conexao);
                return Ok(funcioario);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("BuscarFuncionario")]
        public IActionResult BuscarFuncionario(int IdFuncionario)
        {
            var funcionarioBanco = _conexao.FuncionariosNovos.Where(x => x.Id == IdFuncionario);
            if(funcionarioBanco == null)
            {
                return NotFound();
            }
            return Ok(funcionarioBanco);
        }


        [HttpPut("AtualizarFuncionario")]
        public IActionResult AtualizarFuncionario(Funcioario funcionario)
        {
            var funcionarioBanco = _conexao.FuncionariosNovos.Find(funcionario.Id);
            if(funcionarioBanco == null)
            {
                return NotFound();
            }
            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Endereco = funcionario.Endereco;
            funcionarioBanco.Ramal = funcionario.Ramal;
            funcionarioBanco.EmailProfissional = funcionario.EmailProfissional;
            funcionarioBanco.Departamento = funcionario.Departamento;
            funcionarioBanco.Salario = funcionario.Salario;
            funcionarioBanco.DataCadastro = funcionario.DataCadastro;

            _conexao.FuncionariosNovos.Update(funcionarioBanco);
            _conexao.SaveChanges();

            AdicionarLog(funcionarioBanco.Id, "Editar", "FuncionariosNovos", JsonSerializer.Serialize(funcionarioBanco), _conexao);

            return Ok(funcionarioBanco);
        }


        [HttpDelete("DeletandoFuncionarios")]
        public IActionResult DeletarFuncionario(int IdFuncionario)
        {
            var funcionarioBanco = _conexao.FuncionariosNovos.Find(IdFuncionario);
            if (funcionarioBanco == null)
            {
                return NotFound();
            }
            _conexao.FuncionariosNovos.Remove(funcionarioBanco);
            _conexao.SaveChanges();

            AdicionarLog(funcionarioBanco.Id, "Excluir", "FuncionariosNovos", JsonSerializer.Serialize(funcionarioBanco), _conexao);
            return Ok(funcionarioBanco);
        }
    }
}
