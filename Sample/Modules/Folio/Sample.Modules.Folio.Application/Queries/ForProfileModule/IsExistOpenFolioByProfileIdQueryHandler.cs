using Sample.Modules.Folio.Domain.Folio;
using MediatR;

namespace Sample.Modules.Folio.Application.Queries.ForProfileModule;

public class IsExistOpenFolioByProfileIdQueryHandler : IRequestHandler<IsExistOpenFolioByProfileIdQuery, bool>
{
    private readonly IFolioRepository _folioRepository;

    public IsExistOpenFolioByProfileIdQueryHandler(IFolioRepository folioRepository)
    {
        _folioRepository = folioRepository;
    }

    public Task<bool> Handle(IsExistOpenFolioByProfileIdQuery request, CancellationToken cancellationToken)
    {
        return _folioRepository.IsExistOpenFolioByProfileId(request.ProfileId);
    }
}