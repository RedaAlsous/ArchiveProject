
using MediatR;

namespace Archive.Application.Folders.Command.UpdateFolder;

public class UpdateFolderCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Path { get; set; } = default!;

    public DateOnly CreatedDate { get; set; }

    public DateOnly ModifiedDate { get; set; }
}
