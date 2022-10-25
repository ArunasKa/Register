using RegisterApi.BL.Interfaces;
using RegisterApi.DAL.Interfaces;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Services
{
    public class UserAccountsService : IUserAccountsService
    {
        private readonly IDbRepository _repository;

        public UserAccountsService(IDbRepository dbRepository)
        {
            _repository = dbRepository;
        }

        public async Task<(bool authenticationsuccessful, string? role)> LogInAsync(string userName, string pasword)
        {
            var account = await _repository.GetAccountByUserNameAsync(userName);
            if (account == null)
            {
                return (false, null);
            }
            return (VerifyPasswordHash(pasword, account.PasswordHash, account.PasswordSalt), account.Role);


        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public async Task<bool> CreateUserAccountAsync(string userName, string password)
        {
            var existingUser = await _repository.GetAccountByUserNameAsync(userName);
            if (existingUser != null)
            {
                return false;
            }

            var (hash, salt) = CreatePasswordHash(password);

            var newUser = new UserAccount
            {
                UserName = userName,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };

            await _repository.InsertAccountAsync(newUser);
            await _repository.SaveChangesAsync();

            return true;
        }

        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
    }
}
