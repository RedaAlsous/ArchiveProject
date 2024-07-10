

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Archive.Application.User.Query.GetUserByIdQuery;

public class GetUserByIdQueryCommandHandler(ILogger<GetUserByIdQueryCommandHandler> logger,
   IUserStore<Domain.Entites.User> userStore) : IRequestHandler<GetUserByIdQueryCommand, Domain.Entites.User>
{
    public async Task<Domain.Entites.User> Handle(GetUserByIdQueryCommand request, CancellationToken cancellationToken)
    {
        
        var dbUser = await userStore.FindByIdAsync(request!.Id, cancellationToken);
        return dbUser;


    }
}
