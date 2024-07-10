


using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Shared.Query;

public class GetAllSharedQuery : IRequest<IEnumerable<SharedItem>>
{
}
