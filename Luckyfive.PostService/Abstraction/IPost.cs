using System.Threading.Tasks;

namespace Luckyfive.PostService.Abstraction
{
    public interface IPost
    {
        Task<PostStatusEnum> GetPostStatus(string trackingNumber);
    }
}
