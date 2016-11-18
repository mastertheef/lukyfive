﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Luckyfive.DTO;
using Luckyfive.Service;
using Luckyfive.Service.Abstraction;
using Microsoft.AspNet.Identity;

namespace Luckyfive.Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public ActionResult Options()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetProfileSettings()
        {
            var settings = await this.profileService.GetUserProfileSettings(this.User.Identity.GetUserId());
            if (settings != null)
            {
                return new JsonResult()
                {
                    Data = settings
                };
            }

            return null;
        }

        [HttpPost]
        public async Task<JsonResult> SaveProfileSettings(ProfileSettingsDTO settings)
        {
            settings.UserId = this.User.Identity.GetUserId();
            await this.profileService.SaveProfileSettings(settings);
            return new JsonResult()
            {
                Data = new { success = true }
            };
        }
    }
}