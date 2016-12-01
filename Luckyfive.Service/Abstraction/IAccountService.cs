using System.Threading.Tasks;

namespace Luckyfive.Service.Abstraction
{
    public interface IAccountService
    {
        Task<bool> IsEmailUsed(string email);
    }
}
