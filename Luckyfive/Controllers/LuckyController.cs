using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Luckyfive.DTO;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;
using Microsoft.AspNet.Identity;
using System.Web;
using System.IO;
using System.Linq;
using Luckyfive.DTO.Enums;
using Luckyfive.Web.Properties;

namespace Luckyfive.Web.Controllers
{
    [Authorize]
    public class LuckyController : BaseController
    {
        private const int AdvertismentDuration = 14;
        private readonly IAdvertismentService advertismentService;
        private readonly ICloudService cloudService;

        public LuckyController(IAdvertismentService advertismentService, ICloudService cloudService)
        {
            this.advertismentService = advertismentService;
            this.cloudService = cloudService;
        }

        public ActionResult Create()
        {
            var tempFolder = Server.MapPath(string.Format(Resources.AdvertsmentId, Session.SessionID));

            // clear temp directory for current session
            if (Directory.Exists(tempFolder))
            {
                var files = Directory.EnumerateFiles(tempFolder).ToList();
                files.ForEach(x => System.IO.File.Delete(x));
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateLucky(AdvertismentDTO data)
        {
            data.OwnerId = this.User.Identity.GetUserId();
            data.StartDate = DateTime.Today;
            data.EndDate =  DateTime.Today.AddDays(AdvertismentDuration);
            data.Status = (int) AdvertismentStatusEnum.Approved; // Change to pending when admin site will be done
            data.Lucky = true;
            
            var advId = await this.advertismentService.CreateAdvertismentAsync(data);

            Session[Resources.AdvertsmentId] = advId;
            //TODO: create database entry and set its id in session
            return new JsonResult
            {
                Data = new { success = true }
            };
        }

        [HttpPost]
        public async Task<JsonResult> Upload(HttpPostedFileBase[] files)
        {
            //TODO: save ids of files to db, upload files to s3 and clear session
            var adId = (int) Session[Resources.AdvertsmentId];

            foreach (var file in files)
            {
                var photoId = Guid.NewGuid();
                var fileS3Name = $"{adId}/{photoId + Path.GetExtension(file.FileName)}";
                var photo = new PhotoDTO
                {
                    Id = photoId,
                    AdvId = adId,
                    Url = $"{Resources.AmazonUrl}/{this.cloudService.BucketName}/{fileS3Name}"
                };

                await this.advertismentService.CreatePhotoAsync(photo);
                await this.cloudService.UploadFromStream(fileS3Name, file.InputStream);
            }

            Session[Resources.AdvertsmentId] = null;
            return new JsonResult()
            {
                Data = new {result = true}
            };
        }
    }
}