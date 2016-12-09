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
    /// Demonstrando o Delete, também existe o RemoveRange não foi demonstrado pois a lógica é a mesma do Insert
    /// </summary>
    public class DeleteTest
    {
        [Fact]
        public void Delete_com_referencia_do_objeto()
        {
            using (var con = new Contexto())
            {
                //Remove através do objeto selecionado
                var telefone = con.Set<Telefone>().FirstOrDefault();
                con.Set<Telefone>().Remove(telefone);
                con.SaveChanges();
            }
        }

        [Fact]
        public void Delete_sem_objeto_retornado_do_banco()
        {
            using (var con = new Contexto())
            {
                //Remove mesmo tendo somente o Id
                var telefoneNew = new Telefone() { Id = 80336 };
                con.Entry(telefoneNew).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
            }
        }
        [Fact]
        public void Delete_com_referencia_do_objeto_state()
        {
            using (var con = new Contexto())
            {
                //Esta é a forma que "internamente" é utilizado no Blue, pois para validar a Entidade fazer a busca dos dados
                //E depois setamos para excluído, isto se faz necessário, pois além das validações da regra de negócio, 
                //se necessitarmos saber o valor da entidade antes do delete do registros para fazer uma auditoria por exemplo, 
                //precisamos desta informação
                var telefone = con.Set<Telefone>().FirstOrDefault();
                con.Entry(telefone).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
            }
        }
    }
}
