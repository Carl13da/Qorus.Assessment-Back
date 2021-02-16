using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Qorus.Assessment.Application.CommandHandlers
{
    public class UploadFileCommandHandler : MediatorCommandHandler<UploadFileCommand>
    {
        private readonly IFileService _fileService;

        public UploadFileCommandHandler(IMediatorHandler mediator, IFileService fileService) : base(mediator)
        {
            _fileService = fileService;
        }

        public override async Task AfterValidation(UploadFileCommand request)
        {
            var (hasError, file, error) = await _fileService.UpdateFile(request.FileDto);

            if (hasError)
            {
                NotifyError(error);

                return;
            }

            NotifyCommandResult(file);
        }
    }
}
