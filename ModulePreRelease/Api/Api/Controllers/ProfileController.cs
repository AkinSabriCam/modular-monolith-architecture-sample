using Microsoft.AspNetCore.Mvc;
using Profile.Application.Commands;
using Profile.Application.Contract.Internal;
using Profile.Application.Queries;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileExecutor _profileExecutor;

    public ProfileController(IProfileExecutor reservationExecutor)
    {
        _profileExecutor = reservationExecutor;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateProfileCommand command)
    {
        await _profileExecutor.ExecuteCommand(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProfileDto>>> GetAll()
    {
        return Ok(await _profileExecutor.ExecuteQuery(new GetAllProfilesQuery()));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _profileExecutor.ExecuteCommand(new DeleteProfileCommand(id));
        return Ok();
    }
}