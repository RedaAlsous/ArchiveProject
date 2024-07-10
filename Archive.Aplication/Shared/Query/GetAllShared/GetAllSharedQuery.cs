using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Shared.Query.GetAllShared;

public class GetAllSharedQuery : IRequest<IEnumerable<SharedItem>>
{
}
