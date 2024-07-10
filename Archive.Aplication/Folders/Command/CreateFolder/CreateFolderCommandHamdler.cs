using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Folders.Command.CreateFolder
{
    public class CreateFolderCommandHamdler(ILogger<CreateFolderCommandHamdler> logger,
        IMapper mapper,
        IFolderRepositories folderRepositories) : IRequestHandler<CreateFolderCommand, int>
    {
        public async Task<int> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new Folder {@Folder}", request);
            var Folder = mapper.Map<Efolder>(request);
            int id = await folderRepositories.Create(Folder);
            return id;
        }
    }
}
