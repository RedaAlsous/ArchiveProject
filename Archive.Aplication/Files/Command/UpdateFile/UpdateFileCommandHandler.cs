

using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Files.Command.UpdateFile;

public class UpdateFileCommandHandler(ILogger<UpdateFileCommandHandler> logger,
    IFileRepository fileRepository,
    IMapper mapper) : IRequestHandler<UpdateFileCommand>
{
    public async Task Handle(UpdateFileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating File with id: {FileId} with {@UpdatedFile}", request.Id, request);
        var file = await fileRepository.GetByIdAsync(request.Id);
        if (file == null)
            throw new NotFoundException(nameof(Efile), request.Id.ToString());

        mapper.Map(request, file);

        await fileRepository.SaveChanges();
    }
}
