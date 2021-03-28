using LoanSystem.Core.Entities;
using LoanSystem.Core.Interfaces;
using LoanSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanSystem.Infrastructure.Repositores
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly LoanSystemContext _context;
        protected readonly DbSet<T> _repository;

        public Repository( LoanSystemContext context)
        {

            _context = context;
            _repository = context.Set<T>();
        }

        public Task<List<T>> Get()
        {
            return _repository.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Post(T entity)
        {
            throw new NotImplementedException();
        }

        public void Put(T entity)
        {
            throw new NotImplementedException();
        }


        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
