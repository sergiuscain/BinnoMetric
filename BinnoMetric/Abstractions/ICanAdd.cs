namespace BinnoMetric.Abstractions;
public interface ICanAdd<T>
{
    public Task<T> AddAsync(T value);
    public Task<ICollection<T>> AddRangeAsync(ICollection<T> values);
}
