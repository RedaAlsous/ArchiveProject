using Archive.Application.User;
using Archive.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Archive.Application.Shared.Query.GetSharedItems;

public class GetSharedItemsCommandHandler(ILogger <GetSharedItemsCommandHandler> logger,
    IUserStore<Domain.Entites.User> userStore,
    IUserContext userContext) : IRequestHandler<GetSharedItemsCommand, IEnumerable<SharedItem>>
{
    public async Task<IEnumerable<SharedItem>> Handle(GetSharedItemsCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("GetSharedItems for log in user");
        var user = userContext.GetCurrentUser();

        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
        IEnumerable<SharedItem> sharedItems = dbUser!.SharedItems.ToList();
        return sharedItems;
    }
}
