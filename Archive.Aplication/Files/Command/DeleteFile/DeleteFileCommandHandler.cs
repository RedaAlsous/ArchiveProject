using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Files.Command.DeleteFile;

public class DeleteFileCommandHandler(ILogger<DeleteFileCommandHandler> logger,
    IFileRepository fileRepository) : IRequestHandler<DeleteFileCommand>
{
    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting File with id: {FileId}", request.Id);
        var file = await fileRepository.GetByIdAsync(request.Id);
        if (file == null)
            throw new NotFoundException(nameof(Efile), request.Id.ToString());

        await fileRepository.Delete(file);
    }
}
