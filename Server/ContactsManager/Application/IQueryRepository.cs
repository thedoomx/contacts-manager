namespace Application
{
	using Domain;

	public interface IQueryRepository<in TEntity>
		where TEntity : IAggregateRoot
	{
	}
}
