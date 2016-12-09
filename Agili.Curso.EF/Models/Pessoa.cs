using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agili.Curso.EF.Models
{
    public class TipoPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
    public class Pessoa : IEntityId
    {
        public Pessoa(TipoPessoa tipoPessoa)
        {
            TipoPessoa = tipoPessoa;
        }
        public TipoPessoa TipoPessoa { get; set; }
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Data { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public Pessoa()
        {
            Telefones = new List<Telefone>();
        }
    }
}
