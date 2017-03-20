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
                    return this.advRepo.GetAdvertismentViews()
                        .Where(x => x.OwnerId == userId && x.EndDate >= DateTime.Today).ToList();
                });
            return this.mapAndReturn(found);
        }

        public async Task<AdvertismentDTO> GetAdvertismentById(int id)
        {
            var found = await Task.Run(() => this.advRepo.GetById(id));
            return Mapper.Map<AdvertismentDTO>(found);
        }

        public async Task<List<PhotoDTO>> GetAdevrtismentPhotos(int id)
        {
            var found = await Task.Run(() => this.photoRepo.GetAdvertismentPhotos(id).ToList());
            var result = new List<PhotoDTO>();
            found.ForEach(x=>result.Add(Mapper.Map<PhotoDTO>(x)));
            return result;
        }

        public async Task UpdateAdvertismentAsync(AdvertismentDTO advertisment)
        {
            var adv = this.advRepo.GetById(advertisment.Id);
            adv.Name = advertisment.Name;
            adv.Description = advertisment.Description;
            this.advRepo.Update(adv);
            await this.unitOfWork.CommitAsync();
        }

        public async Task DeletePhotoAsync(Guid id)
        {
            this.photoRepo.Delete(x => x.Id == id);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> HasFirstPhoto(int id)
        {
            return await Task.Run(() => this.photoRepo.GetMany(x => x.AdvId == id).Any(x => x.First));
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
