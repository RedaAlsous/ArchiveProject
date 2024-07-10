using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using Archive.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Shared.Command.DeleteShared
{
    internal class DeleteSharedQueryHandler(ILogger<DeleteSharedQueryHandler> logger,
        ISharedItemRepository sharedItemRepository) : IRequestHandler<DeleteSharedQuery>
    {
        public async Task Handle(DeleteSharedQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting shared with id: {SharedId}", request.Id);
            var shared = await sharedItemRepository.GetByIdAsync(request.Id);
            if (shared == null)
                throw new NotFoundException(nameof(Efolder), request.Id.ToString());

            await sharedItemRepository.Delete(shared);
        }
    }
}
