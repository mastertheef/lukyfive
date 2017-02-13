using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Repositories
{
    public class ProfileRepository : RepositoryBase<ProfileSetting>, IProfileRepository
    {
        public ProfileRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IProfileRepository : IRepository<ProfileSetting>
    {
        
    }
}
