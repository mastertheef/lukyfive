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

        public LuckyController(IAdvertismentService advertismentService)
        {
            this.advertismentService = advertismentService;
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
            
            var advId = await this.advertismentService.CreateAdvertisment(data);

            Session[Resources.AdvertsmentId] = advId;
            //TODO: create database entry and set its id in session
            return new JsonResult
            {
                Data = new { success = true }
            };
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase[] files)
        {
            //TODO: save ids of files to db, upload files to s3 and clear session

            Session[Resources.AdvertsmentId] = null;
            return new JsonResult()
            {
                Data = new {result = true}
            };
        }
    }
}