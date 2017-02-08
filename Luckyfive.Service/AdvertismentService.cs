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
        private readonly IUnitOfWork unitOfWork;

        public AdvertismentService(IAvertismentRepository advRepo, IUnitOfWork unitOfWork)
        {
            this.advRepo = advRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAdvertisment(AdvertismentDTO advertisment)
        {
            var adv = Mapper.Map(advertisment, new Advertisments());
            await this.AddAdvertisment(adv);
            return adv.Id;
        }

        private async Task AddAdvertisment(Advertisments adv)
        {
            this.advRepo.Add(adv);
            await unitOfWork.CommitAsync();
        }
    }
}
