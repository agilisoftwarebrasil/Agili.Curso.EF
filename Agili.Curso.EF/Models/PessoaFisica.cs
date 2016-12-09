using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agili.Curso.EF.Models
{
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public string RG { get; set; }
    }
}
