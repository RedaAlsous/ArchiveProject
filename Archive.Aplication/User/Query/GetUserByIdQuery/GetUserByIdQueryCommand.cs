
using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.User.Query.GetUserByIdQuery;

public class GetUserByIdQueryCommand(string id) : IRequest<Domain.Entites.User>
{
    public string Id { get; } = id;
}
