
using Archive.Application.Folders.Command.CreateFolder;
using Archive.Application.Folders.Command.UpdateFolder;
using Archive.Domain.Entites;
using AutoMapper;

namespace Archive.Application.Folders.Dtos;

public class FolderProfile: Profile
{
    public FolderProfile()
    {
        CreateMap<Efolder, FolderDto>();

        CreateMap<CreateFolderCommand, Efolder>();

        CreateMap<UpdateFolderCommand, Efolder>();
    }
}
