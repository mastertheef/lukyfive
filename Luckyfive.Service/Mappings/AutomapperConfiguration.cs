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
                x.CreateMap<ProfileSettings, ProfileSettingsDTO>();
                x.CreateMap<ProfileSettingsDTO, ProfileSettings>();
            });
        }
    }
}
