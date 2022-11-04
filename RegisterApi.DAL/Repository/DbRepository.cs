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

        public async Task<UserAccount?> GetAccountById(int id)
        {
            return await _context.UserInformation.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserAccount?> GetAccountByUserNameAsync(string username)
        {
            return await _context.UserInformation.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _context.PersonInformation.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task InsertAccountAsync(UserAccount userAccount)
        {
            await _context.UserInformation.AddAsync(userAccount);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void UpdatePerson(Person userToUpdate)
        {
             _context.Update(userToUpdate);
        }
    }
}