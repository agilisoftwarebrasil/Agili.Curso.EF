using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using System.Linq;

namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class ComConfiguracaoMigrationsTest
    {
        [TestMethod]
        public void InsertComConfiguracaoContext()
        {
            using (var con = new ComConfiguracaoMigrationsContext())
            {
                var pessoa = new PessoaFisica() { Nome = "Tânia Física", CPF = "000000" };
                con.Set<PessoaFisica>().Add(pessoa);
                var qtde = con.SaveChanges();
                var dados = con.Set<PessoaJuridica>().AsNoTracking().Where(w => w.Id > 0).ToList();
            }
        }

        [TestMethod]
        public void InsertComConfiguracaoContext_Insert_Pessoa_Juridica()
        {
            using (var con = new ComConfiguracaoMigrationsContext())
            {
                var pessoa = new PessoaJuridica() { Nome = "Tânia Jurídica", CNPJ = "000000" };
                con.Set<PessoaJuridica>().Add(pessoa);
                var qtde = con.SaveChanges();
                var dados = con.Set<PessoaJuridica>().AsNoTracking().Where(w => w.Id > 0).ToList();
            }
        }

        [TestMethod]
        public void InsertComConfiguracaoContext_TodasPessoas()
        {
            using (var con = new ComConfiguracaoMigrationsContext())
            {
                var pessoa = new PessoaJuridica() { Nome = "Tânia Jurídica", CNPJ = "000000" };
                con.Set<PessoaJuridica>().Add(pessoa);
                var qtde = con.SaveChanges();
                var dados = con.Set<PessoaJuridica>().AsNoTracking().Where(w => w.Id > 0).ToList();
            }
        }
    }
}
