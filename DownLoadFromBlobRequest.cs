using MediatR;

namespace pocblueprint.api.Features.DownLoadFromBlob
{
    public record DownLoadFromBlobRequest : IRequest<DownLoadFromBlobResponse>
    {
        public string containerName { get; set; }
        public string fileName { get; set; }

    }
}
