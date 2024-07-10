

using Archive.Domain.Entites;
using MediatR;

namespace Archive.Application.Shared.Command.CreateShared;

public class CreateSharedCommand : IRequest
{
    public int Id { get; set; }
    public string SharedItemUserId { get; set; } = default!;
    public List<Efile> SharedFiles { get; set; } = new();
    public List<Efolder> SharedFolders { get; set; } = new();
}
