using MediatR;
using Profile.Application.Contract.FolioIntegration;
using Profile.Application.Contract.ReservationIntegration;
using Profile.Domain.Profile;

namespace Profile.Application.Commands;

public class DeleteProfileCommandHandler : AsyncRequestHandler<DeleteProfileCommand>
{
    private readonly IProfileDomainService _domainService;
    private readonly IReservationService _reservationService;
    private readonly IFolioService _folioService;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfileCommandHandler(
        IProfileDomainService domainService,
        IReservationService reservationService,
        IUnitOfWork unitOfWork, IFolioService folioService)
    {
        _domainService = domainService;
        _reservationService = reservationService;
        _unitOfWork = unitOfWork;
        _folioService = folioService;
    }

    protected override async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationService.GetReservationsByProfileId(request.Id);

        if (reservations.Any())
            throw new Exception("Can not delete this user because the profile has reservations");

        var isExistOpenFolio = await _folioService.IsExistOpenFolioByProfileId(request.Id);
        
        if (isExistOpenFolio)
            throw new Exception("This profile has at least one open folio. Please be sure that all folios are closed!");
        
        await _domainService.Delete(request.Id);
        await _unitOfWork.SaveChangesAsync();

        await Task.CompletedTask;
    }
}