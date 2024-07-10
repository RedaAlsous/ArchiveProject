
using Microsoft.AspNetCore.Identity;

namespace Archive.Domain.Entites;

public class User :IdentityUser
{


    public List<SharedItem> SharedItems { get; set; } = [];



}
