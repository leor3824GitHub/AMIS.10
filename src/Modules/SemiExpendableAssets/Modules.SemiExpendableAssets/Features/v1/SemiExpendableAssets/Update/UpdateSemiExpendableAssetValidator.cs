using FluentValidation;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Update;

/// <summary>Validator for UpdateSemiExpendableAssetCommand.</summary>
public sealed class UpdateSemiExpendableAssetValidator : AbstractValidator<UpdateSemiExpendableAssetCommand>
{
    public UpdateSemiExpendableAssetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

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
