using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DTO;

namespace Luckyfive.Service.Abstraction
{
    public interface IAdvertismentService
    {
        Task<int> CreateAdvertisment(AdvertismentDTO advertisment);
    }
}
