using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.DTO
{
    public class TelefoneDto : ITelefoneDto
    {
        public long Id { get; set; }
        public string Numero { get; set; }
        public  string TipoTelefone { get; set; }
    }

    public interface ITelefoneDto
    {
        long Id { get; set; }
        string Numero { get; set; }
        string TipoTelefone { get; set; }
    }
}
