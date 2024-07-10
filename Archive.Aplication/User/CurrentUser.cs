

using Archive.Domain.Entites;

namespace Archive.Application.User;

public record CurrentUser(string Id,
    string Email,
    IEnumerable<string> Roles
    //List<SharedItem> SharedItems
    )
{
    public bool IsInRole(string role) => Roles.Contains(role);
    
}
