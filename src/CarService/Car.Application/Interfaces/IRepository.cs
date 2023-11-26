namespace Car.Application.Interfaces;

public interface IRepository<T>
{
    public ValueTask<long> CountAsync();

    public ValueTask<T> GetByIdAsync(long id);

    public ValueTask<IEnumerable<T>> GetAllAsync();

    public ValueTask<long> CreateAsync(T entity);

    public ValueTask<long> UpdateAsync(T entity);

    public ValueTask<long> DeleteAsync(long id);

}
