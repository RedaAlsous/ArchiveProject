
using Archive.Domain.Entites;

namespace Archive.Domain.Repositories;

public interface IFileRepository
{
    Task<IEnumerable<Efile>> GetAllAsync();
    Task<Efile?> GetByIdAsync(int id);
    Task<int> Create(Efile entity);
    Task Delete(Efile entity);
    Task SaveChanges();
}
