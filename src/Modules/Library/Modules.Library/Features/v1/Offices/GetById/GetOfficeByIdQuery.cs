namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public sealed record GetOfficeByIdQuery(Guid Id) : IQuery<OfficeDto>;
