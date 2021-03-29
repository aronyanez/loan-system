using LoanSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanSystem.Core.Services
{
    public interface IService<T>
    {

        Task<List<T>> Get();

        Task<T> GetOne(int id);

        Task Post(T user);

        Task<bool> Put(T user);

        Task<bool> Delete(int id);
    }
}