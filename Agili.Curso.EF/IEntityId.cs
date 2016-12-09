using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF
{
    public interface IEntityId
    {
        long Id { get; set; }
    }
}
