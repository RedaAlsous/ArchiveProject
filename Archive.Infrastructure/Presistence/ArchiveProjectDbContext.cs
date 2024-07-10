
using Archive.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Archive.Infrastructure.Presistence;

internal class ArchiveProjectDbContext(DbContextOptions<ArchiveProjectDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Efile> Files { get; set; }
    internal DbSet<Efolder> folders { get; set; }
    internal DbSet<SharedItem> SharedItems { get; set; }

    public DbSet<CustomError> Errors { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Efolder>()
            .HasMany(r => r.files)
            .WithOne()
            .HasForeignKey(d => d.EfolderId)
            .OnDelete(DeleteBehavior.ClientCascade);

         modelBuilder.Entity<User>()
            .HasMany(e => e.SharedItems)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.SharedItemUserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);








       //   modelBuilder.Entity<SharedItem>()
           //  .HasMany(e => e.User)
            // .WithOne(e => e.SharedItems)
           //  .HasForeignKey(n => n.SharedItemUserId)
          //   .WillCascadeOnDelete(false);
       // .HasRequired(n => n.User)
       // .WithMany(a => a.SharedItems)

    }
}
