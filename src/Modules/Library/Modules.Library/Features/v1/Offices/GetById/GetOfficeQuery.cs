namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public sealed record GetOfficeQuery(Guid Id) : IQuery<OfficeDto>;
