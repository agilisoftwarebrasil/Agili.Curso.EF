using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Agili.Curso.EF.DTO;

namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class LazyLoadingTest
    {
        [TestMethod]
        public void Getpessoa_sem_lazy_loading()
        {
            //Executa um left join com telefone, pois como é um subselect "não pode" garantir que o mesmo exista
            using (var con = new Contexto())
            {
                var dados = (from pessoa in con.Set<PessoaView>()
                             select new PessoaComTelefoneDTO
                             {
                                 Id = pessoa.Id,
                                 Nome = pessoa.Nome,
                                 Telefones = con.Set<Telefone>().Where(w => w.PessoaId == pessoa.Id).Select(s => new TelefoneDTO
                                 {
                                     Numero = s.Numero,
                                     TipoTelefone = s.TipoTelefone.Descricao
                                 })
                             }).ToList();
            }
        }

        [TestMethod]
        public void Getpessoa_sem_lazy_loading_inner_join()
        {
            //Executa Inner Join com Telefone, pois não inclui o DefaultIfEmpty
            using (var con = new Contexto())
            {
                var tel = con.Set<Telefone>();
                var dados = (from pes in con.Set<PessoaView>()
                             from tels in con.Set<Telefone>().Where(w => w.PessoaId == pes.Id)
                             select new PessoaComVinculoTelefoneDTO
                             {
                                 Id = pes.Id,
                                 Nome = pes.Nome,
                                 Numero = tels.Numero,
                                 TipoTelefone = tels.TipoTelefone.Descricao
                             }).ToList();
            }
        }

        [TestMethod]
        public void Select_telefone_fields_types_anonymous()
        {
            //Consulta simples utilizando linq to SQL e projeção tipo anônimo, irá executar inner com tipo de telefone
            //pois o mapeamento mostra que o tipo de telefone é obrigatório
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = (from telefone in con.Set<Telefone>()
                             select new
                             {
                                 telefone.Pessoa.Nome,
                                 TelefoneId = telefone.Id,
                                 Numero = telefone.Numero,
                                 DescricaoTipoTelefone = telefone.TipoTelefone.Descricao
                             }).ToList();

                var dados2 = con.Set<Telefone>().Select(telefone =>
                        new
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
