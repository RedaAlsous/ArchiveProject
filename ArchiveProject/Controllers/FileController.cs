using Archive.Application.Files.Command.CreateFile;
using Archive.Application.Files.Command.DeleteFile;
using Archive.Application.Files.Command.UpdateFile;
using Archive.Application.Files.Query.GetAllFiles;
using Archive.Application.Files.Query.GetFileById;
using Archive.Application.Folders.Command.CreateFolder;
using Archive.Application.Folders.Command.DeleteFolder;
using Archive.Application.Folders.Command.UpdateFolder;
using Archive.Application.Folders.Queries.GetAllFolders;
using Archive.Application.Folders.Queries.GetFolderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveProject.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/files")]
    public class FileController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var files = await mediator.Send(new GetAllFilesQuery());
            return Ok(files);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var File = await mediator.Send(new GetFileByIdQuery(id));
            return Ok(File);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileCommand command)
        {

            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile([FromRoute] int id, UpdateFileCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile([FromRoute] int id)
        {
            await mediator.Send(new DeleteFileCommand(id));

            return NoContent();
        }

        [HttpGet]
        [Route("{id}/download")]
        public async Task<IActionResult> DownloadFile([FromRoute] int id)
        {
            var Files = await mediator.Send(new GetFileByIdQuery(id));
            //var path = Files.Path;
            var filename = Files.Name;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", filename);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", filename);
        }


        [HttpPost]
        [Route("/Uplode")]
        public async Task<IActionResult> UploadeFile(IFormFile file)
        {
            var filename =  file.FileName;
            try
            {
                var extension = Path.GetExtension(filename);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                var compleatepath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files", filename);

                using (var stream = new FileStream(compleatepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex) 
            {

            }
            return Ok(filename);
        }

    }
}
