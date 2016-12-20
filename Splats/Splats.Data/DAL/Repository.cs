using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Splats.Data.DAL
{
	public class Repository <TEntity> : IRepository<TEntity> where TEntity: class 
	{
		protected internal SplatsContext context;
		protected internal DbSet<TEntity> dbSet;

		public Repository(SplatsContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public virtual TEntity GetByID(object id)
		{
			return dbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			dbSet.Add(entity);
			context.SaveChanges();
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
			context.SaveChanges();
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
			context.SaveChanges();
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}
}
