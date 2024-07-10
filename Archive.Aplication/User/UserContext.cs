﻿

using Archive.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using System.Threading;

namespace Archive.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public  class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public  CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        
        if (user == null)
        {
            throw new InvalidOperationException("User context is not present");
        }

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        //var sharedItem = user.FindFirst(c=>c.Type == "SharedItems")?.Value;
        
        return new CurrentUser(userId, email, roles );
    }
}

