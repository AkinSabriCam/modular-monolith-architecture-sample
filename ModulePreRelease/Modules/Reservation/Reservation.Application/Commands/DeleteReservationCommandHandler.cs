using MediatR;
using Reservation.Application.Contract.FolioIntegration;
using Reservation.Application.Contract.Internal;
using Reservation.Domain.Reservation;

namespace Reservation.Application.Commands;

public class DeleteReservationCommandHandler : AsyncRequestHandler<DeleteReservationCommand>
{
    private readonly IReservationDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFolioService _folioService;

    public DeleteReservationCommandHandler(IReservationDomainService domainService, IUnitOfWork unitOfWork, 
        IFolioService folioService)
    {
        _domainService = domainService;
        _unitOfWork = unitOfWork;
        _folioService = folioService;
    }

    protected override async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var isExistOpenFolio = await _folioService.IsExistOpenFolioByReservationId(request.Id);
        
        if(isExistOpenFolio)
            throw new Exception("This reservation has at least one open folio. Please be sure that all folios are closed!");

        await _domainService.Delete(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}