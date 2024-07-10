

using Archive.Domain.Entites;
using Archive.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Archive.Application.User.Command.UpdateUserDetails;

public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserContext userContext,
    
    IUserStore<Domain.Entites.User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {

        //var user = userContext.GetCurrentUser();
        logger.LogInformation("Updateing user : {UserId}, with {@Request}", request!.Id, request);

        var dbUser = await userStore.FindByIdAsync(request!.Id, cancellationToken);

        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), request!.Id);
        }

        dbUser.UserName = request.Name;
        dbUser.Email = request.Email;

       //userManager.Users.ToListAsync();

        await userStore.UpdateAsync(dbUser, cancellationToken);

    }
}
