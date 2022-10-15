using MediatR;
using pocblueprint.Infrastructure.FileStorage;
using System.Threading;
using System.Threading.Tasks;

namespace pocblueprint.api.Features.DownLoadFromBlob
{
    public class DownLoadFromBlobHandler : IRequestHandler<DownLoadFromBlobRequest, DownLoadFromBlobResponse>
    {
        private readonly IFileStorageService _fileStorageService;
        public DownLoadFromBlobHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        public async Task<DownLoadFromBlobResponse> Handle(DownLoadFromBlobRequest request, CancellationToken cancellationToken)
        {
            DownLoadFromBlobResponse downLoadFromBlobResponse = new DownLoadFromBlobResponse();
            downLoadFromBlobResponse.FileStream= await _fileStorageService.DownloadFileAsync(request.containerName, request.fileName);
            downLoadFromBlobResponse.DownLoadFileName = request.fileName;
            return await Task.FromResult(downLoadFromBlobResponse); 
        }      

    }
}
