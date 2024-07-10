

using Archive.Application.Folders.Command.CreateFolder;
using Archive.Application.Shared.Command.CreateShared;
using Archive.Domain.Entites;
using AutoMapper;

namespace Archive.Application.Shared.SharedItemDto;

public class SharedItemProfile : Profile
{
    public SharedItemProfile()
    {
        CreateMap<CreateSharedCommand, SharedItem>();
    }
}
