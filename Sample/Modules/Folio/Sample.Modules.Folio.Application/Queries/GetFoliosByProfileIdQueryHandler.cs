using Sample.Modules.Folio.Domain.Folio;
using MediatR;

namespace Sample.Modules.Folio.Application.Queries;

public class GetFoliosByProfileIdQueryHandler : IRequestHandler<GetFoliosByProfileIdQuery, List<FolioDto>>
{
    private readonly IFolioRepository _repository;

    public GetFoliosByProfileIdQueryHandler(IFolioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FolioDto>> Handle(GetFoliosByProfileIdQuery request, CancellationToken cancellationToken)
    {
        var folios = await _repository.GetByProfileId(request.ProfileId);
        return folios.Select(folio => new FolioDto
        {
            Id = folio.Id,
            Balance = folio.Balance,
            No = folio.No,
            ProfileId = folio.ProfileId,
            ReservationId = folio.ReservationId
        }).ToList();
    }
}