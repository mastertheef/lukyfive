using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luckyfive.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        [HttpGet]
        public ActionResult Options()
        {
            return View();
        }
    }
}