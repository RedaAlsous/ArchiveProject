

using FluentValidation;

namespace Archive.Application.Files.Command.UpdateFile;

public class UpdateFileCommandHandlerValidator : AbstractValidator<UpdateFileCommand>
{
    private readonly List<string> validCategories = ["Music", "Photo", "data", "game", "vedio"];
    public UpdateFileCommandHandlerValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 100)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(dto => dto.Path)
            .NotEmpty().WithMessage("Path is required");

        RuleFor(dto => dto.Type)
            .Must(validCategories.Contains)
            .NotEmpty().WithMessage("categories is required")
            .WithMessage("Invalid category. Please choose from the valid categories.");
            
    }   

}
