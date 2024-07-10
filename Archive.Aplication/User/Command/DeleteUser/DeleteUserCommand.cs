

using MediatR;

namespace Archive.Application.User.Command.DeleteUser;

public class DeleteUserCommand (string id) :IRequest
{
    public string Id { get; } = id;
}
