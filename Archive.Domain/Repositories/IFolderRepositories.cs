
using Archive.Domain.Entites;

namespace Archive.Domain.Repositories;

public interface IFolderRepositories
{
    Task<IEnumerable<Efolder>> GetAllAsync();
    Task<Efolder?> GetByIdAsync(int id);
    Task<int> Create(Efolder entity);
    Task Delete(Efolder entity);
    Task SaveChanges();
}
