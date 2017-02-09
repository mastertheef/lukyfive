using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.Service.Abstraction
{
    public interface ICloudService
    {
        Task Upload(string fileS3Name, string filePath);
        Task Delete(string fileS3Name);
    }
}
