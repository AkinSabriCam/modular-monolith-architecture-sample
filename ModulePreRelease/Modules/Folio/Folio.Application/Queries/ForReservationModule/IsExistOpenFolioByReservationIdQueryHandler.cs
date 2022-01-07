using Folio.Domain.Folio;
using MediatR;

namespace Folio.Application.Queries.ForReservationModule;

public class IsExistOpenFolioByReservationIdQueryHandler : IRequestHandler<IsExistOpenFolioByReservationIdQuery, bool>
{
    private readonly IFolioRepository _repository;

    public IsExistOpenFolioByReservationIdQueryHandler(IFolioRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(IsExistOpenFolioByReservationIdQuery request, CancellationToken cancellationToken)
    {
        return _repository.IsExistOpenFolioByReservationId(request.ReservationId);
    }
}