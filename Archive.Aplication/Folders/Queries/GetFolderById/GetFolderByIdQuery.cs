
using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Folders.Queries.GetFolderById;

public class GetFolderByIdQuery(int id) : IRequest<Efolder>
{
    public int Id { get; } = id;
}
