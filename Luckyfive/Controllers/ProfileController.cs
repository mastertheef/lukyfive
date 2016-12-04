using System.Threading.Tasks;
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
        private readonly IMyEmailService emailService;
        private readonly IAccountService accountService;

        public ProfileController(IProfileService profileService, IMyEmailService emailService, IAccountService accountService)
        {
            this.profileService = profileService;
            this.emailService = emailService;
            this.accountService = accountService;
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

        [HttpPost]
        public async Task<JsonResult> ChangeEmail(string newEmail)
        {
            var isUserd = await this.accountService.IsEmailUsed(newEmail);
            if (!isUserd)
            {
                return new JsonResult()
                {
                    Data = new
                    {
                        success = false
                    }
                };
            }

            var userId = this.User.Identity.GetUserId();
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var postbackUrl = Url.Action("ChangeEmail", "Account", new { userId = userId, code = code, newEmail = newEmail }, protocol: Request.Url.Scheme);

            await this.emailService.SendConfirmationEmail(postbackUrl, newEmail);

            return new JsonResult()
            {
                Data = new
                {
                    success = true
                }
            };
        }
    }
}