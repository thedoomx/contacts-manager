namespace Domain
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDomainRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);

        Task Save(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
