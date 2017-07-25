using Agili.Curso.EF.EntityMap;
using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace Agili.Curso.EF.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto()
           : base("Banco")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<Contexto>(null);
           // this.Database.Log = message => Trace.WriteLine(message);
            //(((IObjectContextAdapter)this).ObjectContext).CommandTimeout = 240;
            this.Database.CommandTimeout = 240;
        }

        public DbSet<Telefone> Telefone { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaFisicaMap());
            modelBuilder.Configurations.Add(new PessoaJuridicaMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new TipoTelefoneMap());
            modelBuilder.Configurations.Add(new CartorioMap());
            modelBuilder.Configurations.Add(new PessoaViewMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }

   
}
