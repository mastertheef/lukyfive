using System.Linq;
using System.Threading.Tasks;
using Luckyfive.DataAccess.Infrastructure;
using Luckyfive.Models;

namespace Luckyfive.DataAccess.Repositories
{
    public class AvertismentRepository : RepositoryBase<Advertisment>, IAvertismentRepository
    {
        private const int CountOfAdvertismentsOnHomePage = 6;

        public AvertismentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IQueryable<TopActualAdvertisment> GetForHomePage()
        {
            return DbContext.TopActualAdvertisments;
        }

        public IQueryable<AdvertismentView> GetAdvertismentViews()
        {
            return DbContext.AdvertismentViews;
        }
    }

    public interface IAvertismentRepository : IRepository<Advertisment>
    {
        IQueryable<TopActualAdvertisment> GetForHomePage();
        IQueryable<AdvertismentView> GetAdvertismentViews();
    }
}
