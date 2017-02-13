using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Repositories
{
    public class PhotoRepository : RepositoryBase<Photos>, IPhotoRepository
    {
        public PhotoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPhotoRepository : IRepository<Photos> { }
}
