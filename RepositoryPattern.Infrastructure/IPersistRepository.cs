using System;
using System.Collections.Generic;

namespace RepositoryPattern.Infrastructure
{
	public interface IPersistRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);
		void Add(IEnumerable<TEntity> items);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		void Delete(IEnumerable<TEntity> entities);
	}
}
