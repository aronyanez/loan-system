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

        public async Task<T> GetById(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async  Task Post(T entity)
        {
            await _repository.AddAsync( entity );
        }

        public void Put(T entity)
        {
            _repository.Update(entity);
        }


        public async  Task DeleteById(int id)
        {
            T entity = await GetById(id);
            _repository.Remove(entity);
        }

    }
}
