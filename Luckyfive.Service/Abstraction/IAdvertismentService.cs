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
        Task<int> CreateAdvertismentAsync(AdvertismentDTO advertisment);
        Task CreatePhotoAsync(PhotoDTO photo);
        Task DeletePhotoAsync(Guid id);
        Task<List<AdvertismentViewDTO>> GetAdvertismentsForHomePage();
        Task<List<AdvertismentViewDTO>> GetAdvertismentsForUser(string userId);
        Task<AdvertismentDTO> GetAdvertismentById(int id);
        Task<List<PhotoDTO>> GetAdevrtismentPhotos(int id);
        Task UpdateAdvertismentAsync(AdvertismentDTO advertisment);
        Task<bool> HasFirstPhoto(int id);
    }
}
