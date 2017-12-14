using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    partial class Repository<T>
        where T : class
    {
        private Context context;

        public Repository()
        {
            context = new Context();
        }

        public T Persist(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified; ;
            return entity;
        }

        public T GetById(int id)
        {

            return this.context.Set<T>().Find(id);

        }

        public IQueryable<T> Set()
        {
            return context.Set<T>();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
