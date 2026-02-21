namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public sealed class GetOfficeByIdHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetOfficeByIdQuery, OfficeDto>
{
    public async ValueTask<OfficeDto> Handle(GetOfficeByIdQuery query, CancellationToken ct)
    {
        var office = await dbContext.Offices.AsNoTracking()
            .Where(x => x.Id == query.Id)
            .Select(x => new OfficeDto(x.Id, x.Name, x.Location, x.Code, x.CreatedOnUtc))
            .FirstOrDefaultAsync(ct) ?? throw new NotFoundException($"Office with id {query.Id} not found");

        return office;
    }
}
