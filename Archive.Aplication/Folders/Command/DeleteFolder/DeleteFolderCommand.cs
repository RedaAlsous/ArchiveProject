

using MediatR;

namespace Archive.Application.Folders.Command.DeleteFolder;

public class DeleteFolderCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
