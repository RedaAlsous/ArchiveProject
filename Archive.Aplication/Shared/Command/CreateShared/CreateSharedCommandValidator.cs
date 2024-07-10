

using FluentValidation;

namespace Archive.Application.Shared.Command.CreateShared;

public class CreateSharedCommandValidator : AbstractValidator<CreateSharedCommand>
{
    public CreateSharedCommandValidator()
    {
        RuleFor(dto => dto.SharedItemUserId)
           .NotEmpty().WithMessage("CreatedDate is required");
    }
}
