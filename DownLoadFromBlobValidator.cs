using FluentValidation;

namespace pocblueprint.api.Features.DownLoadFromBlob
{
    public class DownLoadFromBlobValidator : AbstractValidator<DownLoadFromBlobRequest>
    {
        public DownLoadFromBlobValidator()
        {           
            RuleFor(v => v.containerName)
                .NotEmpty();
            RuleFor(v => v.fileName)
                .NotEmpty();           
        }
       
    }
}
