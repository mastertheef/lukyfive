using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.DataAccess.Repositories;
using Luckyfive.DTO;
using Luckyfive.Models;
using Luckyfive.Service.Abstraction;

namespace Luckyfive.Service
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository profRepo;
        private IUnitOfWork unitOfWork;

        public ProfileService(IProfileRepository profRepo, IUnitOfWork unitOfWork)
        {
            this.profRepo = profRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProfileSettingsDTO> GetUserProfileSettings(string id)
        {
            return await Task.Run(() => Mapper.Map<ProfileSettingsDTO>(this.profRepo.GetById(id)));
        }

        public async Task SaveProfileSettings(ProfileSettingsDTO settings)
        {
            var settingsEntity = Mapper.Map<ProfileSetting>(settings);
            this.profRepo.AddOrUpdate(settingsEntity);
            await unitOfWork.CommitAsync();
        }
    }
}
