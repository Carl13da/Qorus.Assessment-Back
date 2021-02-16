using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Extensions;
using Qorus.Assessment.Domain.Interfaces.Events;
using Qorus.Assessment.Domain.Interfaces.Repositories;
using Qorus.Assessment.Domain.Interfaces.Services;
using Qorus.Assessment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qorus.Assessment.Application.Services
{
    public class FileService : ServiceMediator, IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly string _accessKey;

        public FileService(IMediatorHandler mediator, IFileRepository fileRepository, IConfiguration configuration) : base(mediator)
        {
            _fileRepository = fileRepository;
            _accessKey = configuration["ConnectionStrings:AccessKey"];
        }

        public async Task<Tuple<bool, List<FileDto>, string>> GetAllFiles()
        {
            var files = await _fileRepository.GetAll();

            var resultDto = files.MergeToDestination<List<FileDto>>();

            return Tuple.Create(false, resultDto, string.Empty);
        }

        public async Task<Tuple<bool, FileDto, string>> UpdateFile(UploadFileDto file)
        {
            var url = await UploadFileToBlob(file.Name, file.FileMimeType, file.FileData);

            if (!string.IsNullOrEmpty(url))
            {
                var fileModel = file.MergeToDestination<File>();
                fileModel.URL = url;

                await _fileRepository.Create(fileModel);

                return new Tuple<bool, FileDto, string>(false, fileModel.MergeToDestination<FileDto>(), string.Empty);
            }

            return new Tuple<bool, FileDto, string>(true, null, "Error getting URL");
        }

        private async Task<string> UploadFileToBlob(string fileName, string fileMimeType, byte[] fileData)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_accessKey);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            var strContainerName = "carlossantos";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);

            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            if (fileName != null && fileData != null)
            {
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                cloudBlockBlob.Properties.ContentType = fileMimeType;
                await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
                return cloudBlockBlob.Uri.AbsoluteUri;
            }

            return string.Empty;
        }
    }
}
