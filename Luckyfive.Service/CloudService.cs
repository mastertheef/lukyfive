using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Luckyfive.Service.Abstraction;
using Microsoft.SqlServer.Server;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;

namespace Luckyfive.Service
{
    public class CloudService : ICloudService
    {
        private const string BucketNameKey = "AWSBucketName";
        private static IAmazonS3 client;
        private readonly AWSCredentials awsCredentials;

        private string bucketName => ConfigurationManager.AppSettings[BucketNameKey];

        public CloudService()
        {
            this.awsCredentials = new AppConfigAWSCredentials();
        }

        public async Task Upload(string fileS3Name, string filePath)
        {
            using (client = new AmazonS3Client(this.awsCredentials, Amazon.RegionEndpoint.USEast1))
            {
                await client.UploadObjectFromFilePathAsync(bucketName, fileS3Name, filePath, null);
                // todo: upload file in the bucket luckyfive like 'advId\photoId' I think use Guid for photos in db.
            }
        }

        public async Task Delete(string fileS3Name)
        {
            using (client = new AmazonS3Client(this.awsCredentials, Amazon.RegionEndpoint.USEast1))
            {
                await client.DeleteObjectAsync(bucketName, fileS3Name);
            }
        }
    }
}
