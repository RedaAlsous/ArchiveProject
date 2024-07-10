using Archive.Application.Files.Dtos;
using MediatR;

namespace Archive.Application.Files.Query.GetAllFiles;

public class GetAllFilesQuery : IRequest< IEnumerable<FileDto>>
{
}
