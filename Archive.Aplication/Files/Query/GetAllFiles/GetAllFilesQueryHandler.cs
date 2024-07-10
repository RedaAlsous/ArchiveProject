using Archive.Application.Files.Dtos;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Files.Query.GetAllFiles
{
    public class GetAllFilesQueryHandler(ILogger<GetAllFilesQueryHandler> logger,
    IMapper mapper,
    IFileRepository fileRepository) : IRequestHandler<GetAllFilesQuery, IEnumerable<FileDto>>
    {
        public async Task<IEnumerable<FileDto>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all Files");
            var files = await fileRepository.GetAllAsync();
            var fileDto = mapper.Map<IEnumerable<FileDto>>(files);
            return fileDto;
        }
    }
}
