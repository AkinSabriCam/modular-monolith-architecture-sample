using Sample.Modules.Folio.Domain.Folio;
using MediatR;

namespace Sample.Modules.Folio.Application.Queries;

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