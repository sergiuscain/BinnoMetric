namespace BinnoMetric.Abstractions;
public interface ICanUpdate<T>
{
    public Task<T> UpdateAsync(T value);
}
