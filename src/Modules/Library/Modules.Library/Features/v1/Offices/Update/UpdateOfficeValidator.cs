namespace FSH.Modules.Library.Features.v1.Offices.Update;

public sealed class UpdateOfficeValidator : AbstractValidator<UpdateOfficeCommand>
{
    public UpdateOfficeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Office ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(500).WithMessage("Location must not exceed 500 characters");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(50).WithMessage("Code must not exceed 50 characters");
    }
}
