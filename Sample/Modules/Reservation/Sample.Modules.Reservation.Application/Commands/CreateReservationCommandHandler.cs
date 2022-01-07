using MediatR;
using Sample.Modules.Reservation.Application.Contract.Internal;
using Sample.Modules.Reservation.Domain.Reservation;
using Sample.Modules.Reservation.Domain.Reservation.Dtos;

namespace Sample.Modules.Reservation.Application.Commands;

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