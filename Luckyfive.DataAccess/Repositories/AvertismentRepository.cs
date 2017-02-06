using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Repositories
{
    public class AvertismentRepository : RepositoryBase<Advertisments>, IAvertismentRepository
    {
        public AvertismentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IAvertismentRepository : IRepository<Advertisments>
    {

    }
}
