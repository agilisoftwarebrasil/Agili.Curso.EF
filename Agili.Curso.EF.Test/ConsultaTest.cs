using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.DTO;
using Agili.Curso.EF.Models;
using System.Linq.Expressions;
using System.Linq;

using LinqKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Cursos.EF.Tests
{
    [TestClass]
    public class ConsultaTest
    {
        [TestMethod]
        public void Consulta_dados_com_filtro()
        {
            Query_consulta_dados_com_filtro("teste", null);
            List<Item> teste = new List<Item>
            {
                new Item { Nome = "Teste 1", Id = 1 },
                new Item { Nome = "Teste 2", Id = 2 },
                new Item { Nome = "Teste", Id = 3 }
            };
            var outro = (from te in teste
                         orderby te.Nome, te.Id descending
                         select te).ToList();
            var teste2 = Enumerable.Empty<Item>();
        }
        [TestMethod]
        public void Consulta_dados_com_filtro_contains()
        {
            using (var contexto = new Contexto())
            {
                var nomeItem = "item 1";
                Expression<Func<Item, bool>> filtroItem = x => true;
                if (!string.IsNullOrEmpty(nomeItem))
                    filtroItem = filtroItem.And(x => x.Nome.Contains(nomeItem));
                var projetar = _projetar.Expand();
                var dados2 = from item in contexto.Set<Item>().AsExpandable().Where(filtroItem.Expand())
                             from produto in contexto.Set<Produto>().Where(w => w.ItemId == item.Id)
                             select projetar.Invoke(item, produto, "tste", 50);
                var dados = dados2.ToList();
                Debug.WriteLine($"Total linhas: {dados.Count()}");
            }
        }

        [TestMethod]
        public void Consulta_dados_com_filtro_e_sub2()
        {
            using (var contexto = new Contexto())
            {
                var nomeItem = "item 1";
                Expression<Func<Item, bool>> filtroItem = x => true;
                if (!string.IsNullOrEmpty(nomeItem))
                    filtroItem = filtroItem.And(x => x.Nome.StartsWith(nomeItem));
                var projetar = _projetar.Expand();
                var dados2 = from item in contexto.Set<Item>().AsExpandable().Where(filtroItem.Expand())
                             from produto in contexto.Set<Produto>().Where(w => w.ItemId == item.Id)
                             select new Teste { item = item, produto = produto, Nome = "tste", Id = 50 };
                var dados = dados2.Select(s => new ProdutoDto()
                {
                    Id = s.produto.Id,
                    Nome = s.produto.Nome + "nome " + s.Id,
                    ItemId = s.item.Id,
                    NomeItem = s.item.Nome,
                    Quantidade = s.produto.Quantidade
                }).ToList();
                Debug.WriteLine($"Total linhas: {dados.Count()}");
            }
        }

        [TestMethod]
        public void Consulta_dados_com_filtro_e_sub()
        {
            using (var contexto = new Contexto())
            {
                var nomeItem = "item 1";
                Expression<Func<Item, bool>> filtroItem = x => true;
                if (!string.IsNullOrEmpty(nomeItem))
                    filtroItem = filtroItem.And(x => x.Nome.StartsWith(nomeItem));
                var projetar = _projetar.Expand();
                var dados2 = from item in contexto.Set<Item>().AsExpandable().Where(filtroItem.Expand())
                             from produto in contexto.Set<Produto>().Where(w => w.ItemId == item.Id)
                             select projetar.Invoke(item, produto, "tste", 50);
                var dados = dados2.ToList();
                Debug.WriteLine($"Total linhas: {dados.Count()}");
            }
        }

        Expression<Func<IItem, Produto, string, int, ProdutoDto>> _projetar = (item, produto, nome, id) =>
        new ProdutoDto()
        {
            //Id = produto.Id,
            //Nome = produto.Nome + "nome " + id,
            ItemId = item.Id,
            NomeItem = item.Nome,
            //Quantidade = produto.Quantidade
        };

        [TestMethod]
        public void Consulta_dados_com_filtro_e_query()
        {
            using (var contexto = new Contexto())
            {
                var nomeItem = "test";
                Expression<Func<Item, bool>> filtroItem = x => x.Id != 999;
                //if (!string.IsNullOrEmpty(nomeItem))
                //    filtroItem = filtroItem.And(x => x.Nome.Contains(nomeItem));
                //Expression<Func<IQueryable<Produto>, int>> expression = produto => produto.Sum(s => s.Quantidade);

                var dados2 = from item in contexto.Set<Item>()//.Where(filtroItem.Expand())
                                                              //from produto in contexto.Set<Produto>().Where(w=>w.ItemId == item.Id)
                             select new
                             {
                                 ItemId = item.Id,
                                 NomeItem = item.Nome,
                                 //Total = expression.Expand().Invoke(item.Produtos.AsQueryable())
                             };
                var dados = dados2.ToList();
                Debug.WriteLine($"Total linhas: {dados.Count()}");
            }
        }



        [TestMethod]
        public void Consulta_dados_com_filtro_e_sub_sub()
        {
            //using (var contexto = new Contexto())
            //{
            //    var nomeItem = "test";
            //    Expression<Func<Item, bool>> filtroItem = x => true;
            //    //if (!string.IsNullOrEmpty(nomeItem))
            //    //    filtroItem = filtroItem.And(x => x.Nome.Contains(nomeItem));
            //    Expression<Func<IQueryable<Produto>, int>> expression = produto => produto.Sum(s => s.Quantidade);

            //    var dados2 = from item in contexto.Set<Item>()//.Where(filtroItem.Expand())
            //                 //from produto in contexto.Set<Produto>().Where(w=>w.ItemId == item.Id)
            //                 group item by new { item.Id, item.Nome} into items
            //                 select new
            //                 {
            //                     ItemId = items.Key.Id,
            //                     NomeItem = items.Key.Nome,
            //                     Total = contexto.Set<Produto>().Where(w => w.ItemId == items.Key.Id).
            //                 };
            //    var dados = dados2.ToList();
            //    Debug.WriteLine($"Total linhas: {dados.Count()}");
            //}
        }

        private void Query_consulta_dados_com_filtro(string nomeItem, string nomeProduto)
        {
            using (var contexto = new Contexto())
            {
                Expression<Func<Item, bool>> filtroItem = x => true;
                if (!string.IsNullOrEmpty(nomeItem))
                    filtroItem = filtroItem.And(x => x.Nome.Contains(nomeItem));

                //if (string.IsNullOrEmpty(nomeProduto))
                //    filtroItem = filtroItem.And(x => x.Nome.Contains(nomeItem));
                var dados2 = contexto.Set<Item>().Where(filtroItem.Expand());
                var dados = dados2.ToList();
                Debug.WriteLine($"Total linhas: {dados.Count()}");
            }
        }
    }
}
