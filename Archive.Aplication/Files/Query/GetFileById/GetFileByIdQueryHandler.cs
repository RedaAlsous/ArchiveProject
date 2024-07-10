using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Files.Query.GetFileById;

public class GetFileByIdQueryHandler(ILogger<GetFileByIdQueryHandler> logger,
 IFileRepository fileRepository,
 IMapper mapper) : IRequestHandler<GetFileByIdQuery, Efile>
{
    public async Task<Efile> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all File by {FileId}", request.Id);
        var File = await fileRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Efile), request.Id.ToString());

        var FileDto = mapper.Map<Efile>(File);

        return FileDto;
    }
}
