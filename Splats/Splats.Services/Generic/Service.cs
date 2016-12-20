using Splats.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Services.Generic
{
	public class Service<TEntity> : IService<TEntity> where TEntity: class
	{
		#region Properties
		private readonly IRepository<TEntity> _repository;
		#endregion

		public Service(IRepository<TEntity> entityRepository)
		{
			this._repository = entityRepository;
		}

		public TEntity GetBy(int id)
		{
			return this._repository.GetByID(id);
		}
		public void Insert(TEntity anEntity)
		{
			this._repository.Insert(anEntity);
		}

		public void Update(TEntity anEntity)
		{
			this._repository.Update(anEntity);
		}

		public void Delete(int id)
		{
			this._repository.Delete(id);
		}

		public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			return this._repository.Get(filter, orderBy, includeProperties);
		}
	}
}
