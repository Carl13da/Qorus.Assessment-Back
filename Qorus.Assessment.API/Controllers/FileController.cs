using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qorus.Assessment.API.Abstractions;
using Qorus.Assessment.API.Helpers;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Queries;
using System;
using System.Threading.Tasks;

namespace Qorus.Assessment.API.Controllers
{
    [Route("files")]
    [ApiController]
    public class FileController : ApiController
    {
        public FileController(IMediatorHandler mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            return Response(await Mediator.SendQuery(new GetFilesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, [FromForm] string category, [FromForm] DateTime lastReviewed)
        {
            await Mediator.SendCommand(new UploadFileCommand 
            { 
                FileDto = new UploadFileDto 
                { 
                    Name = file.FileName, 
                    FileData = FilesHelper.GetFileData(file), 
                    FileMimeType = file.ContentType,
                    Category = category,
                    LastReviewed = lastReviewed,
                    Size = file.Length
                }
            });

            return Response();
        }
    }
}
