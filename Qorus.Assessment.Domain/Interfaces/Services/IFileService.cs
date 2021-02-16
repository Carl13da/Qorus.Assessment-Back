using Qorus.Assessment.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qorus.Assessment.Domain.Interfaces.Services
{
    public interface IFileService
    {
        Task<Tuple<bool, List<FileDto>, string>> GetAllFiles();
        Task<Tuple<bool, FileDto, string>> UpdateFile(UploadFileDto file);
    }
}
