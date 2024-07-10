

using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.User.Query.GetAllUserQuery;

public class GetAllUserQueryCommand : IRequest<IEnumerable<Domain.Entites.User>>
{
}
