﻿
using FluentValidation;

namespace Archive.Application.Files.Command.CreateFile;

public class CreateFileCommandHandlerVAlidator : AbstractValidator<CreateFileCommand>
{
    private readonly List<string> validCategories = ["Music", "Photo", "data", "game", "vedio"];
    public CreateFileCommandHandlerVAlidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Name)
            .Length(1, 200);

        RuleFor(dto => dto.Type)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please choose from the valid categories.");
    }
}