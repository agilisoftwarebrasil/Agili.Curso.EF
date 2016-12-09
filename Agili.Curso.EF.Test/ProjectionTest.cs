using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.DTO;
using Agili.Curso.EF.Helpers;
using Agili.Curso.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agili.Curso.EF.Tests
{
    public class ProjectionTest
    {
        [Fact]
        public void Projection_apos_get_page_lazyloading()
        {
            using (var con = new Contexto())
            {
                con.Configuration.LazyLoadingEnabled = true;
                //Este exemplo não é para dizer que não é para utilizar o GetPage do Blue e sim, 
                //que temos que conhecer o que estamos utilizando e quando é o melhor cenário para utilizar
                //desta forma, lembrando que quando eu estou executando este GetPaged antes da projeção ele irá buscar todos os
                //dados de produto, inclusive a Quantidade que não estarei utilizando na projeção
                var dados = con.Set<Produto>()
                    .GetPaged(1, 30)
                    .Select(s => new ProdutoDto()
                    {
                        Id = s.Id,
                        Nome = s.Nome,
                        ItemId = s.ItemId,
                        NomeItem = s.Item.Nome
                    })
                    .ToList();
            }
        }

        [Fact]
        public void Projection_antes_page_sem_utilizar_lazyloading()
        {
            using (var con = new Contexto())
            {
                //Quando vamos utilizar um skip temos que incluir um order by, por este motivo devemos utilizar somente quando
                //Realmente for necessário para que não seja adicionar uma ordenação no banco sem necessidade, pois o banco precisa 
                //realizar um "processamento" para executar o order by
                con.Configuration.LazyLoadingEnabled = true;
                var dados = con.Set<Produto>()
                   //.OrderBy(o => o.Id)
                   //.Skip(2)
                   //.Take(30)
                   .Select(s => new ProdutoDto()
                   {
                       Id = s.Id,
                       Nome = s.Nome,
                       ItemId = s.ItemId,
                       NomeItem = s.Item.Nome
                   })
                   .GetPaged(1, 30)
                   .ToList();
            }
        }

        [Fact]
        public void Projection_produto_tolist_depois_select()
        {
            using (var con = new Contexto())
            {
                con.Configuration.LazyLoadingEnabled = true;
                TestHelp.Restart();
                var dados = con.Set<Produto>()
                    .ToList() //"Nunca" fazer isto e depois fazer o select, o GetPaged do Blue possui um ToList() encapsulado para retornar o PagedCollection
                    .Select(s => new ProdutoDto()
                    {
                        Id = s.Id,
                        Nome = s.Nome,
                        ItemId = s.ItemId,
                        NomeItem = s.Item.Nome
                    }).ToList();
                TestHelp.Stop();
            }
        }

        [Fact]
        public void Projection_produto_sem_utilizar_lazyloading()
        {
            using (var con = new Contexto())
            {
                con.Configuration.LazyLoadingEnabled = true;
                //Desta forma mesmo com o lazy ativo o mesmo "não é utilizado", pois o EF sabe que será utilizado e já faz um Join com o Item
                TestHelp.Restart();
                var dados = con.Set<Produto>()
                    .Select(s => new ProdutoDto()
                    {
                        Id = s.Id,
                        Nome = s.Nome,
                        ItemId = s.ItemId,
                        NomeItem = s.Item.Nome
                    }).ToList();
                TestHelp.Stop();
            }
        }
    }
}
