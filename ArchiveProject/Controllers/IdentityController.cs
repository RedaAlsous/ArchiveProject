using Archive.Application.Folders.Command.UpdateFolder;
using Archive.Application.User.Command.DeleteUser;
using Archive.Application.User.Command.UpdateUserDetails;
using Archive.Application.User.Query.GetAllUserQuery;
using Archive.Application.User.Query.GetUserByIdQuery;
using Archive.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveProject.Controllers;

[Route("api/user")]
[Authorize]
[ApiController]
public class IdentityController(IMediator mediator) : ControllerBase
{

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserDetails([FromRoute] string id , UpdateUserDetailsCommand command)
    {
         command.Id = id;
         await mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] string id)
    {
        await mediator.Send(new DeleteUserCommand(id));

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        var users = await mediator.Send(new GetAllUserQueryCommand());
        return Ok(users);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserAsyncById([FromRoute] string id)
    {
        
        var user = await mediator.Send(new GetUserByIdQueryCommand(id));
        return Ok(user);
    }


    
}
