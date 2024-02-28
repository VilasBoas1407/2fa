namespace TwoFactorAuthenticator.Models.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(string id);
        Task<T> InsertAsync(T item);
        Task<bool> ExistAsync(string id);
    }
}
