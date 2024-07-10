
using FluentValidation;

namespace Archive.Application.Folders.Command.UpdateFolder;

public class UpdateFolderCommandHandlerValidator : AbstractValidator<UpdateFolderCommand>
{
    public UpdateFolderCommandHandlerValidator()
    {
        RuleFor(c => c.Name)
           .Length(3, 100);

    }
}
