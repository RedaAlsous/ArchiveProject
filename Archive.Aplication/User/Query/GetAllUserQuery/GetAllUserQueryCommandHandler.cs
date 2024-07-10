

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Archive.Application.User.Query.GetAllUserQuery;

public class GetAllUserQueryCommandHandler(ILogger<GetAllUserQueryCommandHandler> logger,
    UserManager<Domain.Entites.User> userManager) : IRequestHandler<GetAllUserQueryCommand, IEnumerable<Domain.Entites.User>>
{
    public async Task<IEnumerable<Domain.Entites.User>> Handle(GetAllUserQueryCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Getting all Users");
        return  userManager.Users;
        
    }
}
