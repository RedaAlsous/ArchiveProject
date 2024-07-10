using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Files.Command.CreateFile;

public class CreateFileCommandHandler(ILogger<CreateFileCommandHandler> logger,
    IFileRepository fileRepository,
    IMapper mapper) : IRequestHandler<CreateFileCommand, int>
{
    public async Task<int> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new File {@File}", request);
        var file = mapper.Map<Efile>(request);
        int id = await fileRepository.Create(file);
        return id;
    }
}
