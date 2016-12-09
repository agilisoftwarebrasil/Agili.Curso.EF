using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.EntityMap
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa");
            //1
            this.HasMany(t => t.Telefones)
                .WithRequired(t => t.Pessoa)
                .HasForeignKey(d => d.PessoaId);
        }
    }
}
