using System.IO;

namespace pocblueprint.api.Features.DownLoadFromBlob
{
    public class DownLoadFromBlobResponse
    {
        public FileStream FileStream { get; set; }
        public string DownLoadFileName { get; set; }
        public string ContentType { get; set; } = "application/octet-stream";
    }   
}
