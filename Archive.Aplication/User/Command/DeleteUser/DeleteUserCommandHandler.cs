
using Archive.Application.User.Command.UpdateUserDetails;
using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Archive.Application.User.Command.DeleteUser;

public class DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger,
    IUserContext userContext,
    IUserStore<Domain.Entites.User> userStore
    ) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        
        logger.LogInformation("Deleting user : {UserId}, with {@Request}", request!.Id, request);

        var dbUser = await userStore.FindByIdAsync(request!.Id, cancellationToken);

        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), request!.Id);
        }

        


        await userStore.DeleteAsync(dbUser, cancellationToken);
        
    }
}
