using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Luckyfive.PostService.Abstraction;

namespace Luckyfive.PostService
{
    public class USPS: IPost
    {
        private readonly string USPSUserId = ConfigurationManager.AppSettings["USPSUserId"];
        private const string requestXml = 
@"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<TrackFieldRequest USERID=""{0}"">
    <Revision>1</Revision>
    <ClientIp>111.0.0.1</ClientIp>
    <TrackID ID=""{1}"" />
</TrackFieldRequest>";

        public async Task<PostStatusEnum> GetPostStatus(string trackingNumber)
        {
            var actualXml = string.Format(requestXml, USPSUserId, trackingNumber);
            var url = $"{ConfigurationManager.AppSettings["USPSUrl"]}{actualXml}";
            var webClient = new WebClient();
            webClient.QueryString.Add("API","TrackV2");
            webClient.QueryString.Add("XML", actualXml);
            var result = await webClient.DownloadStringTaskAsync(url);
            var xDoc = XDocument.Parse(result);
            var status = xDoc.Descendants("TrackInfo ").Select(x => x.Name == "Status");

        }
    }
}
