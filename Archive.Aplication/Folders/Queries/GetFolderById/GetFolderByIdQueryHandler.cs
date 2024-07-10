using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Folders.Queries.GetFolderById
{
    public class GetFolderByIdQueryHandler(ILogger<GetFolderByIdQueryHandler> logger,
        IFolderRepositories folderRepositories) : IRequestHandler<GetFolderByIdQuery, Efolder>
    {
        public async Task<Efolder> Handle(GetFolderByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all Folders by {FolderId}", request.Id);
            var folder = await folderRepositories.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Efolder), request.Id.ToString());

            return folder;
        }
    }
}
