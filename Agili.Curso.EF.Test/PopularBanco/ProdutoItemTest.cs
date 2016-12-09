using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agili.Curso.EF.Tests.PopularBanco
{
    public class ProdutoItemTest
    {
        [Fact]
        public void InsertItens()
        {
            using (var con = new Contexto())
            {
                var inserir = new List<Item>();
                for (int i = 1; i < 1000; i++)
                {
                    inserir.Add(new Item() { Nome = $"Item {i}" });
                }
                con.Set<Item>().AddRange(inserir);
                con.SaveChanges();
            }
        }

        [Fact]
        public void InsertProdutos()
        {
            using (var con = new Contexto())
            {
                Random rnd = new Random();
                var inserir = new List<Produto>();
                for (int i = 0; i < 50000; i++)
                    inserir.Add(new Produto() { Nome = $"Produto {i}", ItemId = rnd.Next(1, 999) });
                con.Set<Produto>().AddRange(inserir);
                con.SaveChanges();
            }
        }
    }
}
