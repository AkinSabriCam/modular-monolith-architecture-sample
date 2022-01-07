using MediatR;
using Reservation.Application.Contract.Internal;
using Reservation.Domain.Reservation;
using Reservation.Domain.Reservation.Dtos;

namespace Reservation.Application.Commands;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IReservationDomainService _reservationDomainService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationCommandHandler(IReservationDomainService reservationDomainService, IUnitOfWork unitOfWork)
    {
        _reservationDomainService = reservationDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var result = await _reservationDomainService.Add(new CreateReservationDto()
        {
            Status = request.Status,
            RoomNo = request.RoomNo,
            ProfileId = request.ProfileId
        });

        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}