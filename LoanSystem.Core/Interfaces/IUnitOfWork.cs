using LoanSystem.Core.Entities;
using System.Threading.Tasks;

namespace LoanSystem.Core.Interfaces
{
    public interface IUnitOfWork
    { 
        IRepository<User> UserRepository { get; }
    

        void SaveChanges();

        Task SaveChangesAsync();
    }
}