using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agili.Curso.EF.Models
{
    public class Telefone : IEntityId
    {
        public long Id { get; set; }
        public long PessoaId { get; set; }
        public string Numero { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public long TipoTelefoneId { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
