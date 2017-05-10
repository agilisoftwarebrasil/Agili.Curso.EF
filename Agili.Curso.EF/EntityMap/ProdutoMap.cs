using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.EntityMap
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable(nameof(Produto));
            HasRequired(p => p.Item).WithMany(s=>s.Produtos).HasForeignKey(s => s.ItemId);
            //HasRequired(p => p.Item).WithMany().HasForeignKey(s=>s.ItemId);
            Property(p => p.Quantidade).HasColumnName("Qtde");
        }
    }
}
