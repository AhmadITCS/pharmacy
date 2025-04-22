using EntintyComponent;
using EntintyComponent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Reopsitre
{

    public class Repositre<T> : IReopsitre<T> where T : class
    {
        private readonly PharmacyMangmentContext context;
        private readonly DbSet<T> dbSet;

        public Repositre()
        {
            this.context = new PharmacyMangmentContext();
            this.dbSet = context.Set<T>();
        }


        public void Add(T entity) {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Add(entity);
            context.SaveChanges();

        }
        public void Update(T entity) {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);
            context.SaveChanges();
        }
        public bool Remove(T entity) {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            dbSet.Remove(entity);
            context.SaveChanges();
            return true; }
        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }
        //        IQueryable<TEntity> Find(Exception<Func<TEntity, bool>> exception, params Exception<Func<TEntity, object>>[] includes);{

        public IQueryable<T> Find(Expression<Func<T, bool>> exception, params Expression<Func<T, object>>[] includes)
        {

       IQueryable<T> query = dbSet;

            foreach (var item in includes)
            {

                query = query.Include(item);
            }
            return query.Where(exception);

        }




    }
}
