using LoanSystem.Core.Entities;
using LoanSystem.Core.Exceptions;
using LoanSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSystem.Core.Services
{
    public class UserService : IService<User>
    {


        private readonly IUnitOfWork _unitOfWork;
        public UserService( IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetOne(int id)
        {

            return await _unitOfWork.UserRepository.GetById(id);

        }

        public Task<List<User>> Get()
        {

            return _unitOfWork.UserRepository.Get();
        }

        public async Task Post(User user)
        {
            await  _unitOfWork.UserRepository.Post(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Put(User user)
        {
            var existingPost = await _unitOfWork.UserRepository.GetById(user.Id);
            if( existingPost == null)
            {
                throw Error404.NotFound;
            }

            existingPost.Name = user.Name;
            existingPost.PhoneNumber = user.PhoneNumber;
            existingPost.ApprovedAmount = user.ApprovedAmount;

            _unitOfWork.UserRepository.Put(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async  Task<bool> Delete(int id)
        {
            await _unitOfWork.UserRepository.DeleteById(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
