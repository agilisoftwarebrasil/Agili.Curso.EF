using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.DTO
{
    public class PessoaComTelefoneDTO//
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<TelefoneDTO> Telefones { get; set; }
        public PessoaComTelefoneDTO()
        {
            Telefones = new List<TelefoneDTO>();
        }
    }

    public class PessoaComVinculoTelefoneDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string TipoTelefone { get; set; }
    }

    public class TelefoneDTO
    {
        public string Numero { get; set; }
        public string TipoTelefone { get; set; }
    }
}
