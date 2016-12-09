using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agili.Curso.EF.Models
{
    public class PessoaJuridica : Pessoa
    {
        public string NomeFantasia { get; set; }
        public string  CNPJ { get; set; }
    }
}
