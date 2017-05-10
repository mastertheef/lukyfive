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
                files.ForEach(System.IO.File.Delete);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(id);
        }

        public ActionResult ViewLucky(int id)
        {
            return View(id);
        }

        [HttpPost]
        public async Task<JsonResult> EditLucky(AdvertismentDTO data, EditPhotoDTO[] photos)
        {
            await this.advertismentService.UpdateAdvertismentAsync(data);

            foreach (var photo in photos)
            {
                if (photo.ShouldDelete)
                {
                    await this.advertismentService.DeletePhotoAsync(photo.Id);
                    await this.cloudService.Delete($"{data.Id}/{photo.Name}");
                }
            }

            Session[Resources.AdvertsmentId] = data.Id;
            return new JsonResult
            {
                Data = new {success = true}
            };
        }

        [HttpPost]
        public async Task<JsonResult> GetAdvertismentById(int id)
        {
            var found = await this.advertismentService.GetAdvertismentById(id);
            var result = new JsonResult();
            if (found == null)
            {
                result.Data = new
                {
                    success = false,
                    message = "No advertisment with such id was found."
                };
            }
            else if (found.OwnerId != User.Identity.GetUserId())
            {
                result.Data = new
                {
                    success = false,
                    message = "You are not allowed to edit this advertisment."
                };
            }
            else
            {
                result.Data = new
                {
                    success = true,
                    data = found
                };
            }

            return result;
        }

        [HttpPost]
        public async Task<JsonResult> GetAdvertismentPhotos(int id)
        {
            var found = await this.advertismentService.GetAdevrtismentPhotos(id);
            return new JsonResult
            {
                Data = found
            };
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
            return new JsonResult
            {
                Data = new { success = true }
            };
        }

        [HttpPost]
        public async Task<JsonResult> Upload(HttpPostedFileBase[] files)
        {
            var adId = (int) Session[Resources.AdvertsmentId];
            var first = !await this.advertismentService.HasFirstPhoto(adId);
            foreach (var file in files)
            {
                var photoId = Guid.NewGuid();
                var fileS3Name = $"{adId}/{photoId + Path.GetExtension(file.FileName)}";
                var photo = new PhotoDTO
                {
                    Id = photoId,
                    AdvId = adId,
                    Url = $"{Resources.AmazonUrl}/{this.cloudService.BucketName}/{fileS3Name}",
                    First = first
                };
                first = false;
                await this.advertismentService.CreatePhotoAsync(photo);
                await this.cloudService.UploadFromStream(fileS3Name, file.InputStream);
            }

            Session[Resources.AdvertsmentId] = null;
            return new JsonResult()
            {
                Data = new {result = true}
            };
        }

        [HttpPost]
        public async Task<JsonResult> GetLuckyView(int id)
        {
            var found = await this.advertismentService.GetAdvertismentById(id);
            var result = new JsonResult();
            if (found == null)
            {
                result.Data = new
                {
                    success = false,
                    message = "No advertisment with such id was found."
                };
            }
            else
            {
                result.Data = new
                {
                    success = true,
                    data = found
                };
            }

            return result;
        }
    }
}