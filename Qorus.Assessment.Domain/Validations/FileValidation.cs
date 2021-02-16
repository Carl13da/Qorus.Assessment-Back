using FluentValidation;
using Qorus.Assessment.Domain.Commands;

namespace Qorus.Assessment.Domain.Validations
{
    public class FileValidation : AbstractValidator<UploadFileCommand>
    {
        public FileValidation()
        {
            RuleFor(x => x.FileDto)
                .NotNull()
                .NotEmpty()
                .WithMessage("Object cannot be null");

            When(x => x.FileDto != null, () =>
            {
                RuleFor(x => x.FileDto.Name)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Name cannot be null");

                RuleFor(x => x.FileDto.Category)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Category cannot be null");

                RuleFor(x => x.FileDto.LastReviewed)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("LastReviewed cannot be null");
            });
        }
    }
}
