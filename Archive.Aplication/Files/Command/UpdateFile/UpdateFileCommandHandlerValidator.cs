

using FluentValidation;

namespace Archive.Application.Files.Command.UpdateFile;

public class UpdateFileCommandHandlerValidator : AbstractValidator<UpdateFileCommand>
{
    public UpdateFileCommandHandlerValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 100);
    }

}
