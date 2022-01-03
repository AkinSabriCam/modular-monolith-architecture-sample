using Folio.Domain.Folio;
using MediatR;

namespace Folio.Application.Queries;

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