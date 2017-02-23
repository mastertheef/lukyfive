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
            await this.addPhoto(photoModel);
        }

        private async Task AddAdvertisment(Advertisment adv)
        {
            this.advRepo.Add(adv);
            await unitOfWork.CommitAsync();
        }

        public async Task<List<AdvertismentViewDTO>> GetAdvertismentsForHomePage()
        {
            var found = await Task.Run(() => this.advRepo.GetForHomePage().ToList());
            return this.mapAndReturn(found);
        }

       

        public async Task<List<AdvertismentViewDTO>> GetAdvertismentsForUser(string userId)
        {
            var found =
                await Task.Run(() =>
                {
                    return this.advRepo.GetAdvertismentViews().Where(x => x.OwnerId == userId).ToList();
                });
            return this.mapAndReturn(found);
        }

        private async Task addPhoto(Photo photo)
        {
            this.photoRepo.Add(photo);
            await unitOfWork.CommitAsync();
        }

        private List<AdvertismentViewDTO> mapAndReturn<T>(List<T> found) where T: class
        {
            var result = new List<AdvertismentViewDTO>();
            found.ForEach(x => result.Add(Mapper.Map(x, new AdvertismentViewDTO())));
            return result;
        }
    }
}
