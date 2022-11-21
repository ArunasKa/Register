using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.DAL.Interfaces
{
    public interface IDbRepository
    {
        public  Task<UserAccount?> GetAccountByUserNameAsync(string username);
        public  Task InsertAccountAsync(UserAccount userAccount);
        public  Task SaveChangesAsync();
        public  Task CreatePersonAccountAsync(Person person);
        public Task<UserAccount?> GetAccountById(int id);
        public void SaveChanges();
        public Task<Person?> GetPersonByIdAsync(int id);
        public Task<UserAccount?> GetUserByIdAsync(int id);
        public void DeleteUser(int id);
    }
}
