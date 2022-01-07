using Sample.Modules.Folio.Domain.Folio;
using MediatR;

namespace Sample.Modules.Folio.Application.Queries;

public class GetFoliosByReservationIdQueryHandler : IRequestHandler<GetFoliosByReservationIdQuery, List<FolioDto>>
{
    private readonly IFolioRepository _repository;

    public GetFoliosByReservationIdQueryHandler(IFolioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FolioDto>> Handle(GetFoliosByReservationIdQuery request, CancellationToken cancellationToken)
    {
        var folios = await _repository.GetByReservationId(request.ReservationId);
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