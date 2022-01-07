using Folio.Domain.Folio;
using MediatR;

namespace Folio.Application.Queries;

public class GetFolioByIdQueryHandler : IRequestHandler<GetFolioByIdQuery, FolioDto>
{
    private readonly IFolioRepository _repository;

    public GetFolioByIdQueryHandler(IFolioRepository repository)
    {
        _repository = repository;
    }

    public async Task<FolioDto> Handle(GetFolioByIdQuery request, CancellationToken cancellationToken)
    {
        var folio = await _repository.GetById(request.Id);
        return new FolioDto
        {
            Id = folio.Id,
            Balance = folio.Balance,
            No = folio.No,
            ProfileId = folio.ProfileId,
            ReservationId = folio.ReservationId
        };
    }
}