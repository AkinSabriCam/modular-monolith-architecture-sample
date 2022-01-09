using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Modules.Folio.Application.Commands;
using Sample.Modules.Folio.Application.Contract.Internal;
using Sample.Modules.Folio.Application.Queries;

namespace Sample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FolioController : ControllerBase
{
    private readonly IFolioExecutor _folioExecutor;

    public FolioController(IFolioExecutor folioExecutor)
    {
        _folioExecutor = folioExecutor;
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(CreateFolioCommand command)
    {
        await _folioExecutor.ExecuteCommand(command);
        return Ok();
    }
    
    [HttpPost("close")]
    public async Task<ActionResult> Create(CloseFolioCommand command)
    {
        await _folioExecutor.ExecuteCommand(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<FolioDto>>> GetAll()
    {
        return Ok(await _folioExecutor.ExecuteQuery(new GetAllFoliosQuery()));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<FolioDto>>> GetById(Guid id)
    {
        return Ok(await _folioExecutor.ExecuteQuery(new GetFolioByIdQuery(id)));
    }
}