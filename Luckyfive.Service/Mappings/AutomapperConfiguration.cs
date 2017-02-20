using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Luckyfive.DTO;
using Luckyfive.Models;

namespace Luckyfive.Service.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<ProfileSetting, ProfileSettingsDTO>();
                x.CreateMap<ProfileSettingsDTO, ProfileSetting>();
                x.CreateMap<Advertisment, AdvertismentDTO>();
                x.CreateMap<AdvertismentDTO, Advertisment>();
                x.CreateMap<PhotoDTO, Photo>();
                x.CreateMap<Photo, PhotoDTO>();
                x.CreateMap<TopActualAdvertisment, TopActualAdvertismentDTO>();
                x.CreateMap<TopActualAdvertismentDTO, TopActualAdvertisment>();
            });
        }
    }
}
