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
    /// <summary>
    /// Estes testes irão demonstrar algumas formas de realizar update de dados, devemos avaliar o melhor momento de utilizar cada opção,
    /// lembrando que não é recomendado deixar habilitado o AutoDetectChangesEnabled
    /// No Framework da Ágili já acionar o ChangeTracker.DetectChanges(), indiferentemente da configuração do contexto, com relação ao update 
    /// por propriedades levar em consideração os padrões de projetos para que seja possível balancear em desempenho da aplicação
    /// e padrões utilizados para manter a integridade do objeto(por exemplo, fazer o update diretamente sem passar por uma raiz de agregado)
    /// </summary>
    public class UpdateTest
    {
        [Fact]
        public void Update_com_referencia_do_objeto_sem_auto_detected()
        {
            using (var con = new Contexto())
            {
                //Neste caso não irá realizar a alteração pois esta com o AutoDetectChangesEnabled desabilitado e não o acionei manualmente
                con.Configuration.AutoDetectChangesEnabled = false;
                var pessoa = con.Set<Pessoa>().FirstOrDefault();
                pessoa.Nome = $"{pessoa.Nome } - Alterar";
                con.SaveChanges();
            }
        }

        [Fact]
        public void Update_com_referencia_do_objeto_com_auto_detected()
        {
            using (var con = new Contexto())
            {
                //Como acabei de buscar os dados através do contexto, ele irá conseguir verificar 
                //o que foi alterado automaticamente e somente realizar update na propriedade alterada
                con.Configuration.AutoDetectChangesEnabled = true;
                var pessoa = con.Set<Pessoa>().FirstOrDefault();
                pessoa.Nome = $"{pessoa.Nome } - Alterar";
                con.SaveChanges();
            }
        }

        [Fact]
        public void Update_com_referencia_do_objeto_sem_auto_detected_mas_detectando_manualmente()
        {
            using (var con = new Contexto())
            {
                con.Configuration.AutoDetectChangesEnabled = false;
                var pessoa = con.Set<Pessoa>().FirstOrDefault();
                pessoa.Nome = $"{pessoa.Nome } - Alterar";
                //Preciso acionar a detecção automática, como acabei de buscar os dados através do contexto, 
                //ele irá conseguir ver o que foi alterado e somente realizar update na propriedade alterada
                con.ChangeTracker.DetectChanges();
                con.SaveChanges();
            }
        }

        [Fact]
        public void Update_com_referencia_do_objeto_atualizando_todos_campos()
        {
            using (var con = new Contexto())
            {
                //Como modifique o state manualmente ele irá fazer o update com todas as propriedades
                var pessoa = con.Set<Pessoa>().FirstOrDefault();
                pessoa.Nome = $"{pessoa.Nome } - Alterar";
                var entries = con.ChangeTracker.Entries().Where(w => w.State == System.Data.Entity.EntityState.Modified);

                con.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();
            }
        }

        [Fact]
        public void Update_sem_objeto_retornado_do_banco()
        {
            using (var con = new Contexto())
            {
                //Como modifique o state manualmente ele irá fazer o update com todas as propriedades e setar os valores das propriedades 
                //que não preenchi para o valor nulo ou default 
                var pessoa = new Pessoa { Id = 1, Nome = "Curso EF", Data = new DateTime(2016, 01, 10) };
                con.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                con.SaveChanges();
            }
        }

        [Fact]
        public void Update_sem_objeto_retornado_do_banco_alterar_propriedade_especifica()
        {
            using (var con = new Contexto())
            {
                //Desta forma faz update somente na propriedades que setarmos
                var pessoa = new Pessoa { Id = 1, Nome = "Teste", Data = new DateTime(2016, 01, 8) };
                //O código comentado e o código fazem a mesma coisa
                //con.Entry(pessoa).Property(s => s.Nome).IsModified = true;
                //con.Entry(pessoa).Property(s => s.Data).IsModified = true;
                con.UpdateProperties(pessoa, s => s.Nome);
                con.SaveChanges();
            }
        }
    }
}
