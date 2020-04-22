using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.DataAccess.Abstract
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExist(string username);
    }
}
