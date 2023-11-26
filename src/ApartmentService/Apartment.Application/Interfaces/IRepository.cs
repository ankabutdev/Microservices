namespace Apartment.Application.Interfaces;

public interface IRepository<TEntity>
{
    public ValueTask<int> CreateAsync(TEntity entity);

    public ValueTask<int> UpdateAsync(TEntity entity);

    public ValueTask<int> DeleteAsync(long id);

    public ValueTask<TEntity> GetByIdAsync(long id);

    public ValueTask<long> CountAsync();
}
