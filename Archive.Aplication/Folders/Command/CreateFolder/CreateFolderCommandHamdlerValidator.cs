using FluentValidation;

namespace Archive.Application.Folders.Command.CreateFolder;

public class CreateFolderCommandHamdlerValidator : AbstractValidator<CreateFolderCommand>
{
    public CreateFolderCommandHamdlerValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Path)
            .NotNull();


    }
}
