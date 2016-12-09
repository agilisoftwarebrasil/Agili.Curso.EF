using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agili.Curso.EF.Tests
{
    public class HerancaTPCTest
    {
        [Fact]
        public void InsertTest()
        {
            using (var con = new HerancaTPCContext())
            {
                var pessoa = new PessoaFisica() { Nome = "Tânia Física", CPF = "000000" };
                con.Set<PessoaFisica>().Add(pessoa);
                var qtde = con.SaveChanges();
                var dados = con.Set<PessoaJuridica>().AsNoTracking().Where(w => w.Id > 0).ToList();
            }
        }

    }
}
