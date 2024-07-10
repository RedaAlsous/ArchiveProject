

using MediatR;

namespace Archive.Application.Files.Command.DeleteFile;

public class DeleteFileCommand(int id) :IRequest
{
    public int Id { get; } = id;
}
