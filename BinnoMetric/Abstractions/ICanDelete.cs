namespace BinnoMetric.Abstractions;
public interface ICanDelete<T>
{
    public Task<bool> DeleteAsync(T value);
}
