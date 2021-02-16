using Qorus.Assessment.Domain.Dto;
using Qorus.Assessment.Domain.Validations;

namespace Qorus.Assessment.Domain.Commands
{
    public class UploadFileCommand : Command
    {
        public UploadFileDto FileDto { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new FileValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
