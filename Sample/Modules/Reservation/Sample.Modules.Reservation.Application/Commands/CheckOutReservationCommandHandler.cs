using MediatR;
using Sample.Modules.Reservation.Application.Contract.FolioIntegration;
using Sample.Modules.Reservation.Application.Contract.Internal;
using Sample.Modules.Reservation.Domain.Reservation;

namespace Sample.Modules.Reservation.Application.Commands;

public class CheckOutReservationCommandHandler : AsyncRequestHandler<CheckOutReservationCommand>
{
    private readonly IReservationDomainService _domainService;
    private readonly IFolioService _folioService;
    private readonly IUnitOfWork _unitOfWork;

    public CheckOutReservationCommandHandler(IUnitOfWork unitOfWork, 
        IReservationDomainService domainService, IFolioService folioService)
    {
        _unitOfWork = unitOfWork;
        _domainService = domainService;
        _folioService = folioService;
    }

    protected override async Task Handle(CheckOutReservationCommand request, CancellationToken cancellationToken)
    {
        var isExistOpenFolio = await _folioService.IsExistOpenFolioByReservationId(request.Id);

        if (isExistOpenFolio)
            throw new Exception("This reservation has at least one open folio. Please be sure that all folios are closed!");

        await _domainService.CheckOut(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}