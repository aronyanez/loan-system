using LoanSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanSystem.Core.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<List<T>> Get();
        Task<T> GetById(int id);
        Task Post(T entity);
        void Put(T entity);
        Task DeleteById(int id);
    }
}
