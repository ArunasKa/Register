﻿using Microsoft.EntityFrameworkCore;
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

        public async Task CreatePersonAccountAsync(Person person)
        {
            await _context.PersonInformation.AddAsync(person);
        }

        public async Task<UserAccount?> GetAccountByUserNameAsync(string username)
        {
            return await _context.UserInformation.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task InsertAccountAsync(UserAccount userAccount)
        {
            await _context.UserInformation.AddAsync(userAccount);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
