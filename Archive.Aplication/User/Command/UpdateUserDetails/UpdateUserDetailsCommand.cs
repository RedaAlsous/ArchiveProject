

using MediatR;

namespace Archive.Application.User.Command.UpdateUserDetails;

public class UpdateUserDetailsCommand() : IRequest
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}
