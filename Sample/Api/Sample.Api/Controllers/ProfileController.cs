using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Modules.Profile.Application.Commands;
using Sample.Modules.Profile.Application.Contract.Internal;
using Sample.Modules.Profile.Application.Queries;

namespace Sample.Api.Controllers;

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