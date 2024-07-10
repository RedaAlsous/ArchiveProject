using Archive.Application.Folders.Dtos;
using Archive.Application.User;
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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Archive.Application.Shared.Query.GetAllShared
{
    public class GetAllSharedQueryHandler(ILogger<GetAllSharedQueryHandler> logger,
       ISharedItemRepository sharedItemRepository,
       IUserContext userContext,
       UserManager<Domain.Entites.User> userManager) : IRequestHandler<GetAllSharedQuery, IEnumerable<SharedItem>>
    {
        public async Task<IEnumerable<SharedItem>> Handle(GetAllSharedQuery request, CancellationToken cancellationToken)
        {


            //var user = await userContext.GetCurrentUser();
            // List<SharedItem> sharedItems= user!.SharedItems.ToList();
            logger.LogInformation("Getting all SharedItems");
            var shared = await sharedItemRepository.GetAllAsync();
            return shared;
            //return sharedItems;
        }
    }
}
