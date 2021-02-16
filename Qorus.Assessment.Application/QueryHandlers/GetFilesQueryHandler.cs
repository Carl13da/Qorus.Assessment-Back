using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Interfaces.Services;
using Qorus.Assessment.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qorus.Assessment.Application.QueryHandlers
{
    public class GetFilesQueryHandler : MediatorQueryHandler<GetFilesQuery, List<FileDto>>
    {
        private readonly IFileService _fileService;

        public GetFilesQueryHandler(IMediatorHandler mediator, IFileService fileService) : base(mediator)
        {
            _fileService = fileService;
        }

        public override async Task<List<FileDto>> AfterValidation(GetFilesQuery request)
        {
            var (hasError, files, error) = await _fileService.GetAllFiles();

            if (hasError)
            {
                NotifyError(error);

                return null;
            }

            return files;
        }
    }
}
