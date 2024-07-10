using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using Archive.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.Repositories
{
    internal class FileRepository(ArchiveProjectDbContext dbContext) : IFileRepository
    {

        public async Task<IEnumerable<Efile>> GetAllAsync()
        {
            var files = await dbContext.Files.ToListAsync();
            return files;
        }


        public async Task<Efile?> GetByIdAsync(int id)
        {
            var files = await dbContext.Files
            .FirstOrDefaultAsync(x => x.Id == id);
            return files;
        }

        public async Task<int> Create(Efile entity)
        {
            dbContext.Files.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Efile entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task SaveChanges() => dbContext.SaveChangesAsync();
    }
}
