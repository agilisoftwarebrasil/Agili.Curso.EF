using Agili.Curso.EF.EntityMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Contextos
{
    public class ComConfiguracaoMigrationsContext : DbContext
    {

        public ComConfiguracaoMigrationsContext()
            : base("ComMigrations")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new DropCreateDatabaseAlways<ComConfiguracaoMigrationsContext>());
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaFisicaMap());
            modelBuilder.Configurations.Add(new PessoaJuridicaMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new TipoTelefoneMap());
            modelBuilder.Configurations.Add(new CartorioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
