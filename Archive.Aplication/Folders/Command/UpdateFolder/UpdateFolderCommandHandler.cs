using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Archive.Application.Folders.Command.UpdateFolder;

public class UpdateFolderCommandHandler(ILogger<UpdateFolderCommandHandler> logger,
    IFolderRepositories folderRepositories,
    IMapper mapper) : IRequestHandler<UpdateFolderCommand>
{
    public async Task Handle(UpdateFolderCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Folder with id: {FolderId} with {@UpdatedFolder}", request.Id, request);
        var folder = await folderRepositories.GetByIdAsync(request.Id);
        if (folder == null)
            throw new NotFoundException(nameof(Efolder), request.Id.ToString());

        mapper.Map(request, folder);
           // folder.Name=request.Name;
           // folder.Path=request.Path;
           // folder.CreatedDate=request.CreatedDate;
           // folder.ModifiedDate=request.ModifiedDate;

        await folderRepositories.SaveChanges();
    }
}
