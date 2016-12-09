using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Contextos
{
    public class HerancaTPCContext : DbContext
    {
        public HerancaTPCContext()
           : base("TPC")
        {
            Database.SetInitializer<HerancaTPCContext>(new System.Data.Entity.DropCreateDatabaseAlways<HerancaTPCContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
            modelBuilder.Entity<PessoaFisica>().Ignore(t=>t.Telefones);
            modelBuilder.Entity<PessoaFisica>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PessoaFisica");
            });
            modelBuilder.Entity<PessoaJuridica>().Ignore(t => t.Telefones);
            modelBuilder.Entity<PessoaJuridica>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PessoaJuridica");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
