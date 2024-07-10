
using Archive.Application.Files.Dtos;
using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Files.Query.GetFileById;

public class GetFileByIdQuery(int id) :IRequest<Efile>
{
    public int Id { get; } = id;
}
