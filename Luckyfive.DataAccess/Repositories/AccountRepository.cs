using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luckyfive.DataAccess.Repositories
{
    public class AccountRepository : RepositoryBase<AspNetUsers>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

    }

    public interface IAccountRepository : IRepository<AspNetUsers>
    {
        
    }
}
