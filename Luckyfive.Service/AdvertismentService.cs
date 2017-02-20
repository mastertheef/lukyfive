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
            var adv = Mapper.Map(advertisment, new Advertisment());
            await this.AddAdvertisment(adv);
            return adv.Id;
        }

        public async Task CreatePhotoAsync(PhotoDTO photo)
        {
            var photoModel = Mapper.Map(photo, new Photo());
            await this.AddPhoto(photoModel);
        }

        private async Task AddAdvertisment(Advertisment adv)
        {
            this.advRepo.Add(adv);
            await unitOfWork.CommitAsync();
        }

        public async Task<List<TopActualAdvertismentDTO>> GetAdvertismentsForHomePage()
        {
            var found = await Task.Run(() => this.advRepo.GetForHomePage().ToList());
            var result = new List<TopActualAdvertismentDTO>();
            found.ForEach(x => result.Add(Mapper.Map(x, new TopActualAdvertismentDTO())));
            return result;
        }

        private async Task AddPhoto(Photo photo)
        {
            this.photoRepo.Add(photo);
            await unitOfWork.CommitAsync();
        }
    }
}
