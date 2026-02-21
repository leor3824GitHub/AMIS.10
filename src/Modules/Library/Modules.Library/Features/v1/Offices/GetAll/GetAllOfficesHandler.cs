namespace FSH.Modules.Library.Features.v1.Offices.GetAll;

public sealed class GetAllOfficesHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetAllOfficesQuery, PagedResponse<OfficeDto>>
{
    public async ValueTask<PagedResponse<OfficeDto>> Handle(GetAllOfficesQuery query, CancellationToken ct)
    {
        var offices = dbContext.Offices.AsNoTracking()
            .OrderBy(o => o.Name);

        var dtos = offices.Select(o => new OfficeDto(
            o.Id, o.Name, o.Location, o.Code, o.CreatedOnUtc));

        return await dtos.ToPagedResponseAsync(query, ct);
    }
}
