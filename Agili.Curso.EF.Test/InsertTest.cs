using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        public void Insert_pessoa_juridica_sem_range()
        {
            using (var con = new Contexto())
            {
                var listaPessoa = TestHelp.GetPessoasJuridicas(0);
                TestHelp.Restart();
                foreach (var item in listaPessoa)
                {
                    con.Set<PessoaJuridica>().Add(item);
                }
                TestHelp.Stop(TestHelp.Add);
                TestHelp.Restart();
                var qtde = con.SaveChanges();
                TestHelp.Stop(TestHelp.SaveChanges);
                //Testes: Tempo: 00:01:34.71
                //Testes: Tempo: 00:00:09.35
            }
        }

        [TestMethod]
        public void Insert_pessoa_juridica_com_range()
        {
            using (var con = new Contexto())
            {
                var listaPessoa = TestHelp.GetPessoasJuridicas(0);

                TestHelp.Restart();
                con.Set<PessoaJuridica>().AddRange(listaPessoa);
                TestHelp.Stop(TestHelp.Add);
                TestHelp.Restart();
                var qtde = con.SaveChanges();
                TestHelp.Stop(TestHelp.SaveChanges);
                //Testes: Tempo: 00:00:02.63
                //Testes: Tempo: 00:00:09.35
            }
        }

        [TestMethod]
        public void Insert_pessoa_juridica_sem_range_com_auto_detect_changes_disable()
        {
            using (var con = new Contexto())
            {
                con.Configuration.AutoDetectChangesEnabled = false;
                var listaPessoa = TestHelp.GetPessoasJuridicas(0);
                TestHelp.Restart();
                foreach (var item in listaPessoa)
                {
                    con.Set<PessoaJuridica>().Add(item);
                }
                TestHelp.Stop();
                TestHelp.Restart();
                var qtde = con.SaveChanges();
                TestHelp.Stop();
                //Testes: Tempo: 00:00:02.69
                //Testes: Tempo: 00:00:09.11
            }
        }

        [TestMethod]
        public void Insert_pessoa_fisica_com_range()
        {
            using (var con = new Contexto())
            {
                var listaPessoa = TestHelp.GetPessoasFisica(0);

                TestHelp.Restart();
                con.Set<PessoaFisica>().AddRange(listaPessoa);
                TestHelp.Stop();
                TestHelp.Restart();
                var qtde = con.SaveChanges();
                TestHelp.Stop();
                //Testes: Tempo: 00:00:02.63
                //Testes: Tempo: 00:00:09.35
            }
        }

        [TestMethod]
        public void Insert_pessoa_juridica()
        {
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                con.Set<PessoaJuridica>().Add(TestHelp.GetPessoasJuridicaComTelefone());
                var qtde = con.SaveChanges();
                TestHelp.Stop();
            }
        }
    }
}
