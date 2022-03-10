namespace Infrastructure.Persistence
{
	using Domain;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;

	public abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
		where TDbContext : IDbContext
		where TEntity : class, IAggregateRoot
	{
		protected DataRepository(TDbContext db)
		{
			this.Data = db;
		}

		protected TDbContext Data { get; }

		protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

		public async Task Save(
			TEntity entity,
			CancellationToken cancellationToken = default)
		{
			this.Data.Update(entity);

			await this.Data.SaveChangesAsync(cancellationToken);
		}

		public async Task Save(
		   IEnumerable<TEntity> entities,
		   CancellationToken cancellationToken = default)
		{
			foreach (var entity in entities)
			{
				this.Data.Update(entity);
			}

			await this.Data.SaveChangesAsync(cancellationToken);
		}
	}
}
