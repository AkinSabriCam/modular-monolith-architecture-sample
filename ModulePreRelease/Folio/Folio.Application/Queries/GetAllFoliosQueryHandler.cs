using Folio.Domain.Folio;
using MediatR;

namespace Folio.Application.Queries;

public class GetAllFoliosQueryHandler : IRequestHandler<GetAllFoliosQuery, List<FolioDto>>
{
    private readonly IFolioRepository _repository;

    public GetAllFoliosQueryHandler(IFolioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FolioDto>> Handle(GetAllFoliosQuery request, CancellationToken cancellationToken)
    {
        var folios = await _repository.Get();
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