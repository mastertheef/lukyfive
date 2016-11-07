using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Repositories;
using Luckyfive.DTO;
using Luckyfive.Models;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.Service
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository profRepo;

        public ProfileService(IProfileRepository profRepo)
        {
            this.profRepo = profRepo;
        }

        public async Task<ProfileSettings> GetUserProfileSettings(string id)
        {
            return await Task.Run(() => this.profRepo.GetById(id));
        }

        public async Task SaveProfileSettings(ProfileSettingsDTO setings)
        {
            throw new NotImplementedException();
        }
    }
}
