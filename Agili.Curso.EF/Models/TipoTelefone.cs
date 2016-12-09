using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Models
{
    public class TipoTelefone : IEntityId
    {
        public long Id { get; set; }

        public string Descricao { get; set; }
    }
}
