using LoanSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanSystem.Core.Services
{
    public interface IUserService
    {

        Task<List<User>> GetUsers();

        Task<User> GetUser(int id);

        Task PostUser(User user);

        Task<bool> PutUser(User user);

        Task<bool> DeleteUser(int id);
    }
}