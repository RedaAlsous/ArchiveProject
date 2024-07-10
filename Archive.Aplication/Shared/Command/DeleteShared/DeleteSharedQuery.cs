

using MediatR;

namespace Archive.Application.Shared.Command.DeleteShared;

public class DeleteSharedQuery(int id) : IRequest
{
    public int Id { get; } = id;
}
