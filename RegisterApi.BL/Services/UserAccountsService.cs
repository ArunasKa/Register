using RegisterApi.BL.Interfaces;
using RegisterApi.DAL.Interfaces;
using RegisterApi.Domain.Dtos;
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

        public async Task<bool> CreateUserAccountAsync(SingupDto signupDto)
        {
            var existingUser = await _repository.GetAccountByUserNameAsync(signupDto.UserName);
            if (existingUser != null)
            {
                return false;
            }

            var (hash, salt) = CreatePasswordHash(signupDto.Password);



            using var memoryStream = new MemoryStream();
            signupDto.PersonDto.Image.CopyTo(memoryStream);
            var imageByte = memoryStream.ToArray();
            var newPerson = new Person
            {
                Name = signupDto.UserName,
                LastName = signupDto.PersonDto.LastName,
                PersonalCode = signupDto.PersonDto.PersonalCode,
                PhoneNumber = signupDto.PersonDto.PhoneNumber,
                Email = signupDto.PersonDto.Email,
                ImageBytes = imageByte,
                ImageFileName = signupDto.PersonDto.Image.FileName,
                ImageContentType = signupDto.PersonDto.Image.ContentType,
                
                HomeAddress = new Address
                {
                    City = signupDto.PersonDto.City,
                    StreetName = signupDto.PersonDto.StreetName,
                    HouseNumber = signupDto.PersonDto.HouseNumber,
                    ApartmentNumber = signupDto.PersonDto.ApartmentNumber,
                },

            };

            var newUser = new UserAccount
            {
                UserName = signupDto.UserName,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User",
                Person = newPerson,
            };


            await _repository.InsertAccountAsync(newUser);
            //await _repository.CreatePersonAccountAsync(newPerson);
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
