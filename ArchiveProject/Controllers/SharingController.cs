using Archive.Application.Files.Command.CreateFile;
using Archive.Application.Folders.Command.DeleteFolder;
using Archive.Application.Folders.Queries.GetAllFolders;
using Archive.Application.Folders.Queries.GetFolderById;
using Archive.Application.Shared.Command.CreateShared;
using Archive.Application.Shared.Command.DeleteShared;
using Archive.Application.Shared.Query.GetAllShared;
using Archive.Application.Shared.Query.GetSharedItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveProject.Controllers
{
    [Route("api/share")]
    [ApiController]
    [Authorize]
    public class SharingController(IMediator mediator) : ControllerBase
    {

        


        //  [HttpGet]
        //  public async Task<IActionResult> GetAll()
        //  {
        //      var sharedItems = await mediator.Send(new GetAllSharedQuery());
        //      return Ok(sharedItems);
        //  }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShared([FromRoute] int id)
        {
            await mediator.Send(new DeleteSharedQuery(id));

            return NoContent();
        }



        [HttpGet]
        public async Task<IActionResult> GetForUser()
        {
            var SharedItemsForUser = await mediator.Send(new GetSharedItemsCommand());
            return Ok(SharedItemsForUser);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSharing([FromBody] CreateSharedCommand command)
        {

            await mediator.Send(command);
            return Ok(command);
        }



    }
}
