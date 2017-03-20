using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo, Guid>, IPhotoRepository
    {
        public PhotoRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public IQueryable<Photo> GetAdvertismentPhotos(int advertismentId)
        {
            return dbSet.Where(x => x.AdvId == advertismentId);
        }
    }

    public interface IPhotoRepository : IRepository<Photo, Guid>
    {
        IQueryable<Photo> GetAdvertismentPhotos(int advertismentId);
    }
}
