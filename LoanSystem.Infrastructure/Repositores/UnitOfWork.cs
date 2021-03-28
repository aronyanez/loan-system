using LoanSystem.Core.Entities;
using LoanSystem.Core.Interfaces;
using System.Threading.Tasks;

namespace LoanSystem.Infrastructure.Repositores
{
    public  class UnitOfWork: IUnitOfWork
    {

            private readonly Data.LoanSystemContext _context;
            private readonly IRepository<User> _userRepository;

            public UnitOfWork(Data.LoanSystemContext context)
            {
                _context = context;
            }

            public IRepository<User> UserRepository => _userRepository ?? new Repository<User>(_context);

            public void Dispose()
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }

            public void SaveChanges()
            {
                _context.SaveChanges();
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }
    }


}