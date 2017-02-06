using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Luckyfive.DTO;
using Luckyfive.Models;
using Luckyfive.Service.Abstraction;
using Luckyfive.DataAccess.Repositories;

namespace Luckyfive.Service
{
    class AdvertismentService : IAdvertismentService
    {
        private readonly IAvertismentRepository advRepo;

        public AdvertismentService(IAvertismentRepository advRepo)
        {
            this.advRepo = advRepo;
        }

        public async Task<int> CreateAdvertisment(AdvertismentDTO advertisment)
        {
            var adv = Mapper.Map(advertisment, new Advertisments());
            await Task.Run(() => this.advRepo.Add(adv));
            return adv.Id;
        }
    }
}
