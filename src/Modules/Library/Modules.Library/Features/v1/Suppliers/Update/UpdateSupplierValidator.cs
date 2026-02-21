namespace FSH.Modules.Library.Features.v1.Suppliers.Update;

public sealed class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Supplier ID is required");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(500).WithMessage("Address must not exceed 500 characters");

        RuleFor(x => x.TIN)
            .NotEmpty().WithMessage("Tax ID Number (TIN) is required")
            .MaximumLength(50).WithMessage("TIN must not exceed 50 characters");

        RuleFor(x => x.ContactPerson)
            .NotEmpty().WithMessage("Contact person is required")
            .MaximumLength(200).WithMessage("Contact person must not exceed 200 characters");
    }
}
