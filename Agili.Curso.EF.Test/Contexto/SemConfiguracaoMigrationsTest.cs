using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class SemConfiguracaoMigrationsTest
    {
        [TestMethod]
        public void InsertSemConfiguracaoContext()
        {
            using (var con = new SemConfiguracaoContext())
            {
                var pessoa = new PessoaFisica() { Nome = "Tânia Física", CPF = "000000" };
                con.Set<PessoaFisica>().Add(pessoa);
                var qtde = con.SaveChanges();
                var dados = con.Set<Pessoa>().AsNoTracking().Where(w => w.Id > 0).ToList();
            }
        }
    }
}
