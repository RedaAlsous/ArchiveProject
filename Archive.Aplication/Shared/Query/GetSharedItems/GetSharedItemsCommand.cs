
using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Shared.Query.GetSharedItems;

public class GetSharedItemsCommand :IRequest<IEnumerable<SharedItem>>
{
}
