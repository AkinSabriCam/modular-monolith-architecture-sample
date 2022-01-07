using Folio.Application.Shared;
using Sample.Modules.Folio.Domain.Folio;
using MediatR;

namespace Sample.Modules.Folio.Application.Commands;

public class CloseFolioCommandHandler : AsyncRequestHandler<CloseFolioCommand>
{
    private readonly IFolioDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public CloseFolioCommandHandler(IFolioDomainService domainService, IUnitOfWork unitOfWork)
    {
        _domainService = domainService;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(CloseFolioCommand request, CancellationToken cancellationToken)
    {
        await _domainService.Close(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}