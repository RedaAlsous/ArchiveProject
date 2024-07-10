

using Archive.Domain.Entites;

namespace Archive.Domain.Repositories;

public interface ISharedItemRepository
{
    Task<IEnumerable<SharedItem>> GetAllAsync();

    Task<SharedItem?> GetByIdAsync(int id);
    Task Create(SharedItem entity);


    Task Delete(SharedItem entity);
}
