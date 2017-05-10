using Agili.Curso.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.DTO
{
    public class ProdutoDto : IEntityId
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long ItemId { get; set; }
        public string NomeItem { get; set; }
        public int Quantidade { get; set; }
    }
    public class Teste
    {
        public Item item { get; set; }
        public Produto produto { get; set; }
        public string Nome { get; set; }
        public long Id { get; set; }
    }
}
