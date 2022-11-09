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
        Task<UserAccount?> GetAccountById(int id);
        void UpdatePerson(Person userToUpdate);
        Task<Person?> GetPersonByIdAsync(int id);
        Task<UserAccount?> GetUserByIdAsync(int id);
        void DeleteUser(int id);
    }
}
