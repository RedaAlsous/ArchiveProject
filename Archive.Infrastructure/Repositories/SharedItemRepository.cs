
using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using Archive.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Archive.Infrastructure.Repositories;

internal class SharedItemRepository(ArchiveProjectDbContext dbContext) : ISharedItemRepository
{
    public async Task Delete(SharedItem entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<SharedItem>> GetAllAsync()
    {
        var shared = await dbContext.SharedItems.ToListAsync();
        return shared;
    }

    public async Task<SharedItem?> GetByIdAsync(int id)
    {
        var shared = await dbContext.SharedItems
           .Include(r => r.User)
           .Include(q => q.SharedFiles)
           .Include(q => q.SharedFolders)
           .FirstOrDefaultAsync(x => x.Id == id);
        return shared;
    }
}
