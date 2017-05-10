using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Models
{
    public class Item : IEntityId, IItem
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public Item()
        {
            Produtos = new List<Produto>();
        }
    }

    public interface IItem : IEntityId
    {
        string Nome { get; set; }
    }
}