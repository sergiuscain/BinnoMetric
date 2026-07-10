namespace BinnoMetric.Abstractions;
public interface ICanDelete<T>
{
    public Task<bool> CanDeleteAsync(T value);
}
