

using Archive.Application.User;
using Archive.Domain.Entites;
using Archive.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Shared.Command.CreateShared;

public class CreateSharedCommandHandler(ILogger<CreateSharedCommandHandler> logger,
    IMapper mapper,
    ISharedItemRepository sharedItemRepository,
    IUserContext userContext,
    IUserStore<Domain.Entites.User> userStore) : IRequestHandler<CreateSharedCommand >
{
    public async Task Handle(CreateSharedCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new SharedItem {@SharedItem}", request);

        var user = userContext.GetCurrentUser();

        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
        request.SharedItemUserId = dbUser!.Id;
        var SharedItemss = mapper.Map<SharedItem>(request);
        await sharedItemRepository.Create(SharedItemss);
        
    }
}
