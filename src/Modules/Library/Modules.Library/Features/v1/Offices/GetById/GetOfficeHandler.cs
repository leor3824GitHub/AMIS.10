namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public sealed class GetOfficeHandler : IQueryHandler<GetOfficeQuery, OfficeDto>
{
    private readonly LibraryDbContext _context;

    public GetOfficeHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async ValueTask<OfficeDto> Handle(GetOfficeQuery query, CancellationToken ct)
    {
        var office = await _context.Offices
            .AsNoTracking()
            .Where(o => o.Id == query.Id)
            .Select(o => new OfficeDto(o.Id, o.Name, o.Location, o.Code, o.CreatedOnUtc))
            .FirstOrDefaultAsync(ct);

        return office ?? throw new NotFoundException(nameof(Office), [query.Id.ToString()]);
    }
}
