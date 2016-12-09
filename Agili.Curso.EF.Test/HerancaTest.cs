using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Agili.Curso.EF.DTO;
namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class HerancaTest
    {
        [TestMethod]
        public void Heranca_linq_to_query()
        {
            //Aqui estamos solicitando o objeto de Pessoa, então ele precisará adicionar toda a hierarquia dos dados
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = (from pessoa in con.Set<Pessoa>()
                             select pessoa).ToList();
                TestHelp.Stop();
            }
        }

        [TestMethod]
        public void Heranca_linq()
        {
            //Aqui estamos solicitando o objeto de Pessoa, então ele precisará adicionar toda a hierarquia dos dados
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = con.Set<Pessoa>()
                    .Select(s => s)
                    .ToList();
                TestHelp.Stop();
            }
        }

        [TestMethod]
        public void Heranca_linq_select_field()
        {
            //Aqui estamos solicitando o objeto de Pessoa, mas já estamos projetando os dados que necessitamos, 
            //por este motivo ele não irá realizar a consulta em toda a hierarquia de dados
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                //As duas consultas abaixo retornam o mesmo resultado
                var pessoaLinq = con.Set<Pessoa>().Select(s => s.Nome).ToList();

                var dadosLinq = (from pessoa in con.Set<Pessoa>()
                                 select new PessoaComTelefoneDTO { Nome = pessoa.Nome }).ToList();
                TestHelp.Stop();
            }
        }

        [TestMethod]
        public void Heranca_pessoaview_linq_to_query()
        {
            //Aqui estamos solicitando o objeto de Pessoa, então ele precisará adicionar toda a hierarquia dos dados
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = (from pessoa in con.Set<PessoaView>().Where(w => w.Nome.Contains("teste"))
                             select pessoa).ToList();
                TestHelp.Stop();
            }
        }

        [TestMethod]
        public void Heranca_linq_include()
        {
            //Todas as colunas de pessoa e pessoa física incluindo os Telefones
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = con.Set<PessoaFisica>().Include(s => s.Telefones).ToList();
                TestHelp.Stop();
            }
        }

        [TestMethod]
        public void Heranca_linq_select_fields_telefone()
        {
            //as duas consultas abaixos retornam dados totalmente diferentes.
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = (from pessoa in con.Set<Pessoa>()//.Where(w=>w.Id < 129416)
                             where pessoa.Id < 129416
                             //.Include(s => s.Telefones)
                             select new { pessoa.Id, pessoa.Telefones }).ToList();

                var dados2 = con.Set<Telefone>().Where(w => w.Id < 129416)
                        .Select(telefone => new
                        {
                            telefone.Pessoa.Nome,
                            telefone.Id,
                            telefone.Numero,
                            DescricaoTipoTelefone = telefone.TipoTelefone.Descricao
                        }).ToList();
                TestHelp.Stop();
            }
        }

    }
}