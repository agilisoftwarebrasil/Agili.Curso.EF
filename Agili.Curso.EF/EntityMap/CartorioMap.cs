using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.EntityMap
{
    public class CartorioMap : EntityTypeConfiguration<Cartorio>
    {
        public CartorioMap()
        {
            ToTable(nameof(Cartorio));
        }
    }
}
