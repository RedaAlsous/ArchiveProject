
using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using Archive.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Archive.Infrastructure.Repositories;

internal class FolderRepository(ArchiveProjectDbContext dbContext) : IFolderRepositories
{
    public async Task<IEnumerable<Efolder>> GetAllAsync()
    {
        var folders= await dbContext.folders.ToListAsync();
        return folders;
    }

    public async Task<Efolder?> GetByIdAsync(int id)
    {
        var folders = await dbContext.folders
            .Include(r => r.SubFolders)
            .Include(q=>q.files)
            .FirstOrDefaultAsync(x => x.Id == id);
        return folders;
    }
    
    public async Task<int> Create(Efolder entity)
    {
        dbContext.folders.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Efolder entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }



    public Task SaveChanges() => dbContext.SaveChangesAsync();
}
