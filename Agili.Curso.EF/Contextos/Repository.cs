using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agili.Curso.EF.Contextos
{
    public static class Context
    {
        public static void UpdateProperties<T>(this DbContext Context, T entity, params Expression<Func<T, object>>[] properties) where T : class
        {
            DbEntityEntry<T> entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Context.Set<T>().Attach(entity);
            foreach (var property in properties)
                entry.Property(property).IsModified = true;
        }
    }
}
