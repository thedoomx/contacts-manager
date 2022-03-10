namespace Domain.Factories.Common
{
    public interface IFactory<out TEntity>
        where TEntity : class
    {
        TEntity Build();
    }
}
