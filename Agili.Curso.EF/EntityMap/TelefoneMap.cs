using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.EntityMap
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable(nameof(Telefone));
            //1 - 
            //HasRequired(s => s.Pessoa)
            //    .WithMany(s => s.Telefones)
            //    .HasForeignKey(s => s.PessoaId);

            HasRequired(p => p.TipoTelefone)
                .WithMany()
                .HasForeignKey(p => p.TipoTelefoneId);
        }
    }
}
