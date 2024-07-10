using Archive.Application.Files.Command.CreateFile;
using Archive.Application.Files.Command.UpdateFile;
using Archive.Application.Files.Query.GetFileById;
using Archive.Application.Folders.Command.CreateFolder;
using Archive.Domain.Entites;
using AutoMapper;

namespace Archive.Application.Files.Dtos;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<Efile, FileDto>();

        CreateMap<CreateFileCommand, Efile>();
        CreateMap<UpdateFileCommand, Efile>();

    }
}
