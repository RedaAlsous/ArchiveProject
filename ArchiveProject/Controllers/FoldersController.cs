using Archive.Application.Folders.Command.CreateFolder;
using Archive.Application.Folders.Command.DeleteFolder;
using Archive.Application.Folders.Command.UpdateFolder;
using Archive.Application.Folders.Queries.GetAllFolders;
using Archive.Application.Folders.Queries.GetFolderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveProject.API.Controllers;

[ApiController]
[Authorize]
[Route("api/folders")]
public class FoldersController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Folders = await mediator.Send(new GetAllFolderQuery());
        return Ok(Folders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var Folder = await mediator.Send(new GetFolderByIdQuery(id));
        return Ok(Folder);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFolder([FromRoute] int id, UpdateFolderCommand command)
    {
        command.Id = id;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFolder([FromRoute] int id)
    {
        await mediator.Send(new DeleteFolderCommand(id));

        return NoContent();
    }
}
