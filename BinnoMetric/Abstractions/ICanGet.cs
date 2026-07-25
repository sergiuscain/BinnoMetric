namespace BinnoMetric.Abstractions;
public interface ICanGet<T>
{
    public Task<T> GetAsync(int id);
    public Task<ICollection<T>> GetAllAsync();
}
