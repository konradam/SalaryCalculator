using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.DAL.Interfaces;
using SalaryCalculator.Domain.Models;
using SalaryCalculator.Web.Data;

namespace SalaryCalculator.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private GenericRepository<Account> _accountRepository;

        public IGenericRepository<Account> AccountRepository
        {
            get
            {
                return _accountRepository = _accountRepository ?? new GenericRepository<Account>(_context);
            }
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
