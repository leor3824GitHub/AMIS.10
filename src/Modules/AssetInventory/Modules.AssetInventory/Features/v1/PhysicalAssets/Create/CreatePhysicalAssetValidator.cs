using FluentValidation;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Create;

/// <summary>Validator for CreatePhysicalAssetCommand.</summary>
public sealed class CreatePhysicalAssetValidator : AbstractValidator<CreatePhysicalAssetCommand>
{
    public CreatePhysicalAssetValidator()
    {
        RuleFor(x => x.PropertyNumber)
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

        RuleFor(x => x.UsefulLifeDays)
            .GreaterThan(0);

        RuleFor(x => x.ResidualValue)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Condition)
            .NotEmpty()
            .Must(c => Enum.GetNames(typeof(AssetCondition)).Contains(c))
            .WithMessage("Invalid condition value");

        RuleFor(x => x.Status)
            .NotEmpty()
            .Must(s => Enum.GetNames(typeof(AssetStatus)).Contains(s))
            .WithMessage("Invalid status value");
    }
}
