using Folio.Application.Shared;
using Sample.Modules.Folio.Domain.Folio;
using Sample.Modules.Folio.Domain.Folio.Dtos;
using MediatR;

namespace Sample.Modules.Folio.Application.Commands;

public class CreateFolioCommandHandler : AsyncRequestHandler<CreateFolioCommand>
{
    private readonly IFolioDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFolioCommandHandler(IFolioDomainService domainService, 
        IUnitOfWork unitOfWork)
    {
        _domainService = domainService;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(CreateFolioCommand request, CancellationToken cancellationToken)
    {
        _domainService.Create(new CreateFolioDto
        {
            No = request.No,
            Balance = request.Balance,
            ProfileId = request.ProfileId,
            ReservationId = request.ReservationId
        });

        await _unitOfWork.SaveChangesAsync();
    }
}