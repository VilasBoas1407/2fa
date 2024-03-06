using MongoDB.Bson;
using TwoFactorAuthenticator.Domain.Entity;

namespace TwoFactorAuthenticator.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(ObjectId id);
        Task<T> InsertAsync(T item);
        Task<bool> ExistAsync(ObjectId id);
    }
}
