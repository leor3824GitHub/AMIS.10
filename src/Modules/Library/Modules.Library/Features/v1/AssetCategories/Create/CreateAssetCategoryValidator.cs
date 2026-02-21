namespace FSH.Modules.Library.Features.v1.AssetCategories.Create;

public sealed class CreateAssetCategoryValidator : AbstractValidator<CreateAssetCategoryCommand>
{
    public CreateAssetCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .MaximumLength(50).WithMessage("Code must not exceed 50 characters");
    }
}
