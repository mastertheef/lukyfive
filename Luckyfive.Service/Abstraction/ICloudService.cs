using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Service.Abstraction
{
    public interface ICloudService
    {
        string BucketName { get; }
        Task Upload(string fileS3Name, string filePath);
        Task UploadFromStream(string fileS3Name, Stream fileStream);
        Task Delete(string fileS3Name);
    }
}
