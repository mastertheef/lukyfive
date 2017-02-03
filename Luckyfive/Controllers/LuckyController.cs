using System.Threading.Tasks;
using System.Web.Mvc;
using Luckyfive.DTO;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;
using Microsoft.AspNet.Identity;
using System.Web;
using System.IO;
using System.Linq;
using Luckyfive.Web.Properties;

namespace Luckyfive.Web.Controllers
{
    [Authorize]
    public class LuckyController : BaseController
    {
        public ActionResult Create()
        {
            var tempFolder = Server.MapPath(string.Format(Resources.tempFolderPath, Session.SessionID));

            // clear temp directory for current session
            if (Directory.Exists(tempFolder))
            {
                var files = Directory.EnumerateFiles(tempFolder).ToList();
                files.ForEach(x => System.IO.File.Delete(x));
            }
            return View();
        }

        [HttpPost]
        public JsonResult CreateLucky(LuckyDTO data)
        {
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

            return new JsonResult()
            {
                Data = new {result = true}
            };
        }
    }
}