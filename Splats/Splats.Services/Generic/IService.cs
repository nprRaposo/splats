using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splats.Services.Generic
{
	public interface IService <TEntity>
	{
		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");

		TEntity GetBy(int id);

		void Insert(TEntity entity);

		void Delete(int id);

		void Update(TEntity entityToUpdate);
	}
}
