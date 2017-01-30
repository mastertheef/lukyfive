using System.Threading.Tasks;
using System.Web.Mvc;
using Luckyfive.DTO;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;
using Microsoft.AspNet.Identity;


namespace Luckyfive.Web.Controllers
{
    [Authorize]
    public class LuckyController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload(object file)
        {
            return new JsonResult()
            {
                Data = new {result = true}
            };
        }
    }
}