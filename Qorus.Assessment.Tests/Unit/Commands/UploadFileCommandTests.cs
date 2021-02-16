using Moq;
using Qorus.Assessment.Application.CommandHandlers;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Interfaces.Services;
using Qorus.Assessment.Tests.Unit.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Qorus.Assessment.Tests.Unit.Commands
{
    public class UploadFileCommandTests
    {
        [Fact(DisplayName = "Should isValid equals false when has no payload")]
        public void ShouldIsValidEqualsFalseWhenHasNoPayload()
        {
            var request = new UploadFileCommand { FileDto = new UploadFileDto() };

            Assert.False(request.IsValid());
        }

        [Fact(DisplayName = "Should call file service")]
        public async Task ShouldCallTransactionService()
        {
            // Arrange
            var mediator = new MockMediatorHandler();
            var fileService = new Mock<IFileService>();

            fileService
                .Setup(t => t.UpdateFile(It.IsAny<UploadFileDto>()))
                .Returns(Task.FromResult(Tuple.Create(false, new FileDto(), "")));

            // Act
            var handler = MockHandler(mediator, fileService.Object);

            await handler.AfterValidation(new UploadFileCommand
            {
                FileDto = new UploadFileDto
                {
                    Category = "test",
                    Name = "test",
                    Size = 2000,
                    LastReviewed = DateTime.Now
                }
            });

            // Assert
            fileService.Verify(mock => mock.UpdateFile(It.IsAny<UploadFileDto>()), Times.Once());
        }

        private UploadFileCommandHandler MockHandler(MockMediatorHandler mediator = null, IFileService fileService = null)
        {
            return new UploadFileCommandHandler(mediator ?? new MockMediatorHandler(), fileService ?? new Mock<IFileService>().Object);
        }
    }
}
