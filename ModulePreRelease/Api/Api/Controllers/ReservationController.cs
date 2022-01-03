using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Commands;
using Reservation.Application.Contract.Internal;
using Reservation.Application.Queries;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationExecutor _reservationExecutor;

    public ReservationController(IReservationExecutor reservationExecutor)
    {
        _reservationExecutor = reservationExecutor;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateReservationCommand command)
    {
        await _reservationExecutor.ExecuteCommand(command);
        return Ok();
    }
    
    [HttpPost("checkout")]
    public async Task<ActionResult> CheckOut(CheckOutReservationCommand command)
    {
        await _reservationExecutor.ExecuteCommand(command);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationDto>>> GetAll()
    {
        return Ok(await _reservationExecutor.ExecuteQuery(new GetAllReservationsQuery()));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _reservationExecutor.ExecuteCommand(new DeleteReservationCommand(id));
        return Ok();
    }
}