using Agili.Curso.EF.Contextos;
using Agili.Curso.EF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Tests
{
    [TestClass]
    public class GetAllTest
    {
        [TestMethod]
        public void GetAll()
        {
            using (var con = new Contexto())
            {
                con.Configuration.AutoDetectChangesEnabled = true;
                TestHelp.Restart();
                var dados = con.Set<Pessoa>()
                    .ToList();
                TestHelp.Stop();
                //Testes: Tempo: 00:00:03.81
            }
        }

        [TestMethod]
        public void Getall_com_auto_detect_changes_disable()
        {
            using (var con = new Contexto())
            {
                //Não há diferença habilitando ou não a configuração, pois o framework quem 
                //controla
                TestHelp.Restart();
                var dados = con.Set<PessoaView>().ToList();
                var qtde = con.ChangeTracker.Entries().Count();
                TestHelp.Stop();
                //Testes: Tempo: 00:00:03.79
            }
        }

        [TestMethod]
        public void Getall_as_notracking()
        {
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = con.Set<PessoaFisica>().AsNoTracking().ToList();
                TestHelp.Stop();
                //Testes: Tempo: 00:00:03.18 = 20%
            }
        }

        [TestMethod]
        public void Getall_queryable()
        {
            using (var con = new Contexto())
            {
                TestHelp.Restart();
                var dados = con.Set<PessoaFisica>().AsNoTracking().ToList();
                foreach (var item in dados)
                {
                    item.Nome = item.Nome;
                }
                TestHelp.Stop();
            }
        }
    }
}
