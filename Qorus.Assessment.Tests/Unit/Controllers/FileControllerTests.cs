using Microsoft.AspNetCore.Http;
using Moq;
using Qorus.Assessment.API.Controllers;
using Qorus.Assessment.Domain.Commands;
using Qorus.Assessment.Tests.Unit.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Qorus.Assessment.Tests.Unit.Controllers
{
    public class FileControllerTests
    {
        [Fact]
        public async Task UploadFileShouldCallUploadFileCommand()
        {
            // Arrange
            var mediator = new MockMediatorHandler();
            var controller = MockController(mediator);
            var fileMock = new Mock<IFormFile>();

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            // Act
            await controller.Upload(fileMock.Object, "test", DateTime.Now);

            // Assert
            Assert.True(mediator.HasNotificationWithType<UploadFileCommand>());
        }

        private FileController MockController(MockMediatorHandler mediator = null)
        {
            return new FileController(mediator: mediator ?? new MockMediatorHandler());
        }
    }
}
