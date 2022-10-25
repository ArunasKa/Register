using Microsoft.EntityFrameworkCore;
using RegisterApi.DAL.Interfaces;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.DAL.Repository
{
    public class DbRepository : IDbRepository
    {
        private readonly FullStackDbContext _context;

        public DbRepository(FullStackDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetAccountByUserNameAsync(string username)
        {
            return await _context.RegisterUserAccounts.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task InsertAccountAsync(UserAccount userAccount)
        {
            await _context.RegisterUserAccounts.AddAsync(userAccount);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
