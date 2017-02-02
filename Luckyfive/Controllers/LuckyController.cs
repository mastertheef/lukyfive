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
        public JsonResult Upload(HttpPostedFileBase[] files)
        {
            var tempFolder = Server.MapPath(string.Format(Resources.tempFolderPath, Session.SessionID));
            var file = files.First();

            if (!Directory.Exists(tempFolder)) {
                Directory.CreateDirectory(tempFolder);
            }

            using (var fileStream = System.IO.File.Create(tempFolder))
            {
                file.InputStream.Seek(0, SeekOrigin.Begin);
                file.InputStream.CopyTo(fileStream);
            }

            return new JsonResult()
            {
                Data = new {result = true}
            };
        }
    }
}