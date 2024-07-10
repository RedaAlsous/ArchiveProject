

using Archive.Application.Folders.Dtos;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Folders.Queries.GetAllFolders;

public class GetAllFolderQueryHandler(ILogger<GetAllFolderQueryHandler> logger,
    IMapper mapper,
    IFolderRepositories folderRepositories) : IRequestHandler<GetAllFolderQuery, IEnumerable<FolderDto>>
{
    public async Task<IEnumerable<FolderDto>> Handle(GetAllFolderQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all Folders");
        var folders = await folderRepositories.GetAllAsync();
        var folderDto = mapper.Map<IEnumerable<FolderDto>>(folders);
        return folderDto;
    }
}
