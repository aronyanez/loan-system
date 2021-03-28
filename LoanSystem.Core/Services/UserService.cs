using LoanSystem.Core.Entities;
using LoanSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Core.Services
{
    public class UserService : IUserService
    {


        private readonly IUnitOfWork _unitOfWork;
        public UserService( IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(int id)
        {

            return await _unitOfWork.UserRepository.GetById(id);

        }

        public Task<List<User>> GetUsers()
        {

            return _unitOfWork.UserRepository.Get();
        }

        public async Task PostUser(User user)
        {
            
        }

        public async Task<bool> PutUser(User user)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.DeleteById(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
