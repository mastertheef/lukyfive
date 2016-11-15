using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DTO;
using Luckyfive.Models;

namespace Luckyfive.Service.Abstraction
{
    public interface IProfileService
    {
        Task<ProfileSettingsDTO> GetUserProfileSettings(string id);
        Task SaveProfileSettings(ProfileSettingsDTO settings);
    }
}
