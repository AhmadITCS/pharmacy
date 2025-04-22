using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Reopsitre
{
	public interface IReopsitre<T> where T : class
	{
		void Add(T entity);
		void Update(T entity);
		bool Remove(T entity);
		IQueryable<T> GetAll();
		//IQueryable<TEntity> Find(Exception<Func<TEntity, bool>> exception, params Exception<Func<TEntity, object>>[] includes);
	    IQueryable<T> Find(Expression<Func<T, bool>> exception,params Expression<Func<T, object>>[] includes);
	}
    
    
}
