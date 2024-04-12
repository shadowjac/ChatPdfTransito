using FluentValidation;

namespace CodigoTransitoReader.Application.Files.CreateFile;

internal class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();
        RuleFor(c => c.SourceId)
            .NotEmpty();
        RuleFor(c => c.NumPages)
            .GreaterThanOrEqualTo(1);
    }
}