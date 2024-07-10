
using MediatR;

namespace Archive.Application.Files.Command.UpdateFile;

public class UpdateFileCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Path { get; set; } = default!;
    public long Size { get; set; }
    public string Type { get; set; } = default!;

    public DateOnly CreatedDate { get; set; }
    public DateOnly ModifiedDate { get; set; }

    public int EfolderId { get; set; }
}
