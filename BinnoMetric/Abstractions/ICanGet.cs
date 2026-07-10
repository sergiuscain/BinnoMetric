namespace BinnoMetric.Abstractions;
public interface ICanGet<T>
{
    public Task<T> GetAsync(string id);
    public Task<ICollection<T>> GetAllAsync();
}
