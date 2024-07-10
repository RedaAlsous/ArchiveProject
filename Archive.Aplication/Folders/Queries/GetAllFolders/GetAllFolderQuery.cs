using Archive.Application.Folders.Dtos;
using MediatR;


namespace Archive.Application.Folders.Queries.GetAllFolders;

public class GetAllFolderQuery :IRequest<IEnumerable <FolderDto>>
{
}
