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

        public Task<User> GetUser(int id)
        {

            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {

            return _unitOfWork.UserRepository.Get();
        }

        public Task PostUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
