using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.DTO;
using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agili.Curso.EF.Tests
{
    public class InnerLeftTest
    {
        [Fact]
        public void Pessoa_com_telefone_inner()
        {
            using (var con = new Contexto())
            {
                //Sem o DefaultIfEmpty irá consultar com inner join por padrão
                var dados = from pessoa in con.Set<PessoaView>()
                            from telefone in con.Set<Telefone>().Where(w=>w.PessoaId == pessoa.Id)
                            where pessoa.Id < 1000
                            select new PessoaComVinculoTelefoneDTO()
                            {
                                Id = pessoa.Id,
                                Nome = pessoa.Nome,
                                Numero = telefone.Numero,
                                TipoTelefone = telefone.TipoTelefone.Descricao
                            };
                var teste = dados.ToList();
                TestHelp.Stop();
            }
        }

        [Fact]
        public void Pessoa_com_telefone_left_outra_forma()
        {
            using (var con = new Contexto())
            {
                //Com o DefaultIfEmpty desta forma irá consultar com left, 
                //mas irá fazer um subselect com condição 1 = 1 e não utilizará o índice do banco
                var dados = from pessoa in con.Set<PessoaView>()
                            from telefone in con.Set<Telefone>().DefaultIfEmpty().Where(w => w.PessoaId == pessoa.Id)
                            where pessoa.Id < 1000
                            select new PessoaComVinculoTelefoneDTO()
                            {
                                Id = pessoa.Id,
                                Nome = pessoa.Nome,
                                Numero = telefone.Numero,
                                TipoTelefone = telefone.TipoTelefone.Descricao
                            };
                var teste = dados.ToList();
            }
        }

        [Fact]
        public void Pessoa_com_telefone_left()
        {
            using (var con = new Contexto())
            {
                //Com o DefaultIfEmpty desta forma irá consultar com left e utilizará o índice do banco corretamente
                var dados = from pessoa in con.Set<PessoaView>()
                            from telefone in con.Set<Telefone>().Where(w => w.PessoaId == pessoa.Id).DefaultIfEmpty()
                            where pessoa.Id < 1000
                            select new PessoaComVinculoTelefoneDTO()
                            {
                                Id = pessoa.Id,
                                Nome = pessoa.Nome,
                                Numero = telefone.Numero,
                                TipoTelefone = telefone.TipoTelefone.Descricao
                            };
                var teste = dados.ToList();
            }
        }
    }
}
