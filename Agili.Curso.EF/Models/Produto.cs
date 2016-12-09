using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Models
{
    public class Produto : IEntityId
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
