using FluentValidation;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Create;

/// <summary>Validator for CreateSemiExpendableAssetCommand.</summary>
public sealed class CreateSemiExpendableAssetValidator : AbstractValidator<CreateSemiExpendableAssetCommand>
{
    public CreateSemiExpendableAssetValidator()
    {
        RuleFor(x => x.ICSNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Category)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.AcquisitionCost)
            .GreaterThan(0);
    }
}
