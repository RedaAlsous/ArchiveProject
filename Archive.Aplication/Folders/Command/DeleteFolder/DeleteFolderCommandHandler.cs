
using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Folders.Command.DeleteFolder;

public class DeleteFolderCommandHandler(ILogger<DeleteFolderCommandHandler> logger,
        IFolderRepositories folderRepositories) : IRequestHandler<DeleteFolderCommand>
{
    public async Task Handle(DeleteFolderCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting Folder with id: {FolderId}", request.Id);
        var folder = await folderRepositories.GetByIdAsync(request.Id);
        if (folder == null)
            throw new NotFoundException(nameof(Efolder), request.Id.ToString());

        await folderRepositories.Delete(folder);
    }
}
