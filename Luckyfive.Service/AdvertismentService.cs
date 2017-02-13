using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.DTO;
using Luckyfive.Models;
using Luckyfive.Service.Abstraction;
using Luckyfive.DataAccess.Repositories;

namespace Luckyfive.Service
{
    class AdvertismentService : IAdvertismentService
    {
        private readonly IAvertismentRepository advRepo;
        private readonly IPhotoRepository photoRepo;
        private readonly IUnitOfWork unitOfWork;

        public AdvertismentService(
            IAvertismentRepository advRepo, 
            IUnitOfWork unitOfWork,
            IPhotoRepository photoRepo)
        {
            this.advRepo = advRepo;
            this.unitOfWork = unitOfWork;
            this.photoRepo = photoRepo;
        }

        public async Task<int> CreateAdvertismentAsync(AdvertismentDTO advertisment)
        {
            var adv = Mapper.Map(advertisment, new Advertisments());
            await this.AddAdvertisment(adv);
            return adv.Id;
        }

        public async Task CreatePhotoAsync(PhotoDTO photo)
        {
            var photoModel = Mapper.Map(photo, new Photos());
            await this.AddPhoto(photoModel);
        }

        private async Task AddAdvertisment(Advertisments adv)
        {
            this.advRepo.Add(adv);
            await unitOfWork.CommitAsync();
        }

        private async Task AddPhoto(Photos photo)
        {
            this.photoRepo.Add(photo);
            await unitOfWork.CommitAsync();
        }
    }
}
